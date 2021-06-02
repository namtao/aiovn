package com.nvn.mylife.Activity;

import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v4.app.Fragment;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.widget.ExpandableListAdapter;
import android.widget.ExpandableListView;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.bumptech.glide.Glide;
import com.google.android.gms.auth.api.Auth;
import com.google.android.gms.auth.api.signin.GoogleSignInAccount;
import com.google.android.gms.auth.api.signin.GoogleSignInOptions;
import com.google.android.gms.auth.api.signin.GoogleSignInResult;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.common.api.OptionalPendingResult;
import com.google.android.gms.common.api.ResultCallback;
import com.google.android.gms.common.api.Status;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import com.nvn.mylife.Fragment.AlphabeFragment;
import com.nvn.mylife.Fragment.CalendarFragment;
import com.nvn.mylife.Fragment.GameFragment;
import com.nvn.mylife.Fragment.HelloFragment;
import com.nvn.mylife.Entities.MenuModel;
import com.nvn.mylife.Fragment.InfoFragment;
import com.nvn.mylife.Fragment.LibraryFragment;
import com.nvn.mylife.Fragment.PaintFragment;
import com.nvn.mylife.Fragment.VideoFragment;
import com.nvn.mylife.Fragment.VocabularyFragment;
import com.nvn.mylife.R;
import com.nvn.mylife.Services.NotifyService;
import com.nvn.mylife.Util.NotificationUtil;
import com.nvn.mylife.Util.ServiceUtil;

public class MainActivity extends AppCompatActivity implements GoogleApiClient.OnConnectionFailedListener {

    private DrawerLayout dl;
    private ActionBarDrawerToggle actionBarDrawerToggle;
    //private FloatingActionButton fab;
    private FrameLayout mDrawFrameLayout;
    ImageView header;
    GoogleApiClient googleApiClient;
    TextView tenDangNhap, email;
    ExpandableListAdapter expandableListAdapter;
    ExpandableListView expandableListView;
    List<MenuModel> headerList = new ArrayList<>();
    HashMap<MenuModel, List<MenuModel>> childList = new HashMap<>();
    MenuModel model;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        init();
        prepareMenuData();
        populateExpandableList();
        googleLogin();
        //FloatingActionButton
        /*  fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //VISIBLE: hiện
                if (mDrawFrameLayout.getVisibility() == View.VISIBLE) {
                    //GONE: ẩn
                    mDrawFrameLayout.setVisibility(View.GONE);
                    Fragment fragment = getSupportFragmentManager().findFragmentById(R.id.draw_container);
                    if (fragment != null) {
                        getSupportFragmentManager().beginTransaction().remove(fragment).commit();
                    }
                } else {
                    mDrawFrameLayout.setVisibility(View.VISIBLE);
                    //gọi fragment BottomSheetFragment lên FrameLayout
                    getSupportFragmentManager().beginTransaction().replace(R.id.draw_container, new BottomSheetFragment()).commit();
                }

            }
        });*/
        //navigation
        /*NavigationView navigationView = findViewById(R.id.nav_view);
          navigationView.setNavigationItemSelectedListener(new NavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem menuItem) {
                int id = menuItem.getItemId();
                dl.closeDrawers();
                switch (id) {
                    case R.id.chucai:
                        getSupportFragmentManager().beginTransaction().replace(R.id.main_content, new ChuCaiFragment()).commit();
                        break;
                    case R.id.convat:
                        getSupportFragmentManager().beginTransaction().replace(R.id.main_content, new ConVatFragment()).commit();
                        break;
                    case R.id.tomau:
                        getSupportFragmentManager().beginTransaction().replace(R.id.main_content, new ToMauFragment()).commit();
                        break;
                    case R.id.phim:
                        getSupportFragmentManager().beginTransaction().replace(R.id.main_content, new PhatVideoFragment()).commit();
                        break;
                    case R.id.word:
                        getSupportFragmentManager().beginTransaction().replace(R.id.main_content, new WordFragment()).commit();
                        break;
                    case R.id.practice:
                        getSupportFragmentManager().beginTransaction().replace(R.id.main_content, new GameFragment()).commit();
                        break;
                    case R.id.game:
                        getSupportFragmentManager().beginTransaction().replace(R.id.main_content, new FragmentTrangDau()).commit();
                        break;
                    case R.id.library:
                        getSupportFragmentManager().beginTransaction().replace(R.id.main_content, new ThuVienFragment()).commit();
                        break;
                    case R.id.thongtin:
                        getSupportFragmentManager().beginTransaction().replace(R.id.main_content, new ThongTinFragment()).commit();
                        break;
                    case R.id.dangxuat:
                        logOut();
                    default://Toast.makeText(TrangChu.this,"chọn đi",Toast.LENGTH_SHORT).show();
                }
                return true;
            }
        });*/
    }

    private void googleLogin() {
        GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DEFAULT_SIGN_IN).requestEmail().build();
        googleApiClient = new GoogleApiClient.Builder(this).
                enableAutoManage(this, this).
                addApi(Auth.GOOGLE_SIGN_IN_API, gso).build();
    }

    public void init() {
        //fab = findViewById(R.id.btn_fab);
        mDrawFrameLayout = (FrameLayout) findViewById(R.id.draw_container);
        header = findViewById(R.id.header);
        tenDangNhap = findViewById(R.id.tendangnhap);
        email = findViewById(R.id.email);
        expandableListView = findViewById(R.id.expandableListView);
        dl = (DrawerLayout) findViewById(R.id.draw_layout);

        actionBarDrawerToggle = new ActionBarDrawerToggle(this, dl, R.string.Open, R.string.Close);
        actionBarDrawerToggle.setDrawerIndicatorEnabled(true);
        dl.addDrawerListener(actionBarDrawerToggle);
        actionBarDrawerToggle.syncState();

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.draw_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    private void prepareMenuData() {

        MenuModel menuModel = new MenuModel("Hello World!!!", true, false, new HelloFragment()); //Menu of Android Tutorial. No sub menus
        headerList.add(menuModel);

        if (!menuModel.hasChildren) {
            childList.put(menuModel, null);
        }

        menuModel = new MenuModel("Kids", true, true, null); //Menu of Java Tutorials
        headerList.add(menuModel);
        List<MenuModel> childModelsList = new ArrayList<>();
        MenuModel childModel = new MenuModel("Alphabe", false, false, new AlphabeFragment());
        childModelsList.add(childModel);

        childModel = new MenuModel("Paint", false, false, new PaintFragment());
        childModelsList.add(childModel);

        childModel = new MenuModel("Video", false, false, new VideoFragment());
        childModelsList.add(childModel);

        childModel = new MenuModel("Vocabulary", false, false, new VocabularyFragment());
        childModelsList.add(childModel);

        childModel = new MenuModel("Game", false, false, new GameFragment());
        childModelsList.add(childModel);

        childModel = new MenuModel("Library", false, false, new LibraryFragment());
        childModelsList.add(childModel);

        if (menuModel.hasChildren) {
            Log.d("API123", "here");
            childList.put(menuModel, childModelsList);
        }

        childModelsList = new ArrayList<>();
        menuModel = new MenuModel("Utilities", true, true, null);
        headerList.add(menuModel);
        childModel = new MenuModel("Note", false, false, null);
        childModelsList.add(childModel);

        childModel = new MenuModel("Calendar", false, false, new CalendarFragment());
        childModelsList.add(childModel);

        if (menuModel.hasChildren) {
            childList.put(menuModel, childModelsList);
        }

        menuModel = new MenuModel("Infomation", true, false, new InfoFragment()); //Menu of Android Tutorial. No sub menus
        headerList.add(menuModel);

        if (!menuModel.hasChildren) {
            childList.put(menuModel, null);
        }

        menuModel = new MenuModel("Logout", true, false, null); //Menu of Android Tutorial. No sub menus
        headerList.add(menuModel);

        if (!menuModel.hasChildren) {
            childList.put(menuModel, null);
        }
    }

    private void populateExpandableList() {

        expandableListAdapter = new com.nvn.mylife.Adapter.ExpandableListAdapter(this, headerList, childList);
        expandableListView.setAdapter(expandableListAdapter);

        expandableListView.setOnGroupClickListener(new ExpandableListView.OnGroupClickListener() {

            @Override
            public boolean onGroupClick(ExpandableListView parent, View v, int groupPosition, long id) {

                if (headerList.get(groupPosition).isGroup) {
                    if (!headerList.get(groupPosition).hasChildren) {
                        if (headerList.get(groupPosition).getFragment() == null)
                            if (headerList.get(groupPosition).getMenuName().equals("Logout")) {
                                logOut();
                                stopService(new Intent(getBaseContext(), NotifyService.class));
                            } else onBackPressed();
                        else {
                            getSupportFragmentManager().beginTransaction().replace(R.id.main_content, headerList.get(groupPosition).getFragment()).commit();
                            onBackPressed();
                        }
                    }
                }

                return false;
            }
        });

        expandableListView.setOnChildClickListener(new ExpandableListView.OnChildClickListener() {
            @Override
            public boolean onChildClick(ExpandableListView parent, View v, int groupPosition, int childPosition, long id) {

                if (childList.get(headerList.get(groupPosition)) != null) {
                    model = childList.get(headerList.get(groupPosition)).get(childPosition);
                    getSupportFragmentManager().beginTransaction().replace(R.id.main_content, model.getFragment()).commit();
                    onBackPressed();
                }

                return false;
            }
        });
    }

    //login google
    @Override
    protected void onStart() {
        super.onStart();
        OptionalPendingResult<GoogleSignInResult> opr = Auth.GoogleSignInApi.silentSignIn(googleApiClient);
        if (opr.isDone()) {
            if (!ServiceUtil.isMyServiceRunning(getApplicationContext(), NotifyService.class)) {
                startService(new Intent(this, NotifyService.class));
            }
            GoogleSignInResult result = opr.get();
            handleSignInResult(result);
        } else {
            opr.setResultCallback(new ResultCallback<GoogleSignInResult>() {
                @Override
                public void onResult(@NonNull GoogleSignInResult googleSignInResult) {
                    handleSignInResult(googleSignInResult);
                }
            });
        }
    }

    private void handleSignInResult(@NonNull GoogleSignInResult result) {
        if (result.isSuccess()) {
            if (!ServiceUtil.isMyServiceRunning(getApplicationContext(), NotifyService.class)) {
                startService(new Intent(this, NotifyService.class));
            }
            GoogleSignInAccount account = result.getSignInAccount();
            tenDangNhap.setText(account.getDisplayName());
            Glide.with(this).load(account.getPhotoUrl()).into(header);
            email.setText(account.getEmail());
        } else {
            Intent intent = new Intent(this, LoginActivity.class);
            startActivity(intent);
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        return actionBarDrawerToggle.onOptionsItemSelected(item) || super.onOptionsItemSelected(item);
    }

    @Override
    public void onConnectionFailed(@NonNull ConnectionResult connectionResult) {
        Toast.makeText(MainActivity.this, "Login fail", Toast.LENGTH_SHORT).show();
    }

    //logout google
    public void logOut() {
        Auth.GoogleSignInApi.signOut(googleApiClient).setResultCallback(new ResultCallback<Status>() {
            @Override
            public void onResult(@NonNull Status status) {
            if (status.isSuccess()) {
                Intent intent = new Intent(MainActivity.this, LoginActivity.class);
                startActivity(intent);
            } else
                Toast.makeText(MainActivity.this, "Logout fail", Toast.LENGTH_SHORT).show();
            }
        });
    }
}
