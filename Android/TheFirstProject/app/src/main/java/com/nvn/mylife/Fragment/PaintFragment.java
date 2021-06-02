package com.nvn.mylife.Fragment;

import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RelativeLayout;

import com.nvn.mylife.CustomView.CustomViewPager;
import com.nvn.mylife.Adapter.PaintAdapter;
import com.nvn.mylife.Entities.Screenshots;
import com.nvn.mylife.R;
public class PaintFragment extends Fragment {
    private CustomViewPager viewPager;
    private PaintAdapter paintAdapter;
    RelativeLayout main;
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        super.onCreateView(inflater, container, savedInstanceState);
        View view= inflater.inflate(R.layout.fragment_paint,container,false);
        viewPager= view.findViewById(R.id.vp_tomau);
        main=view.findViewById(R.id.main);
        paintAdapter = new PaintAdapter(getActivity().getSupportFragmentManager(),getContext());
        viewPager.setAdapter(paintAdapter);
        setHasOptionsMenu(true);
        return view;
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        getActivity().getMenuInflater().inflate(R.menu.menu,menu);
        super.onCreateOptionsMenu(menu,inflater);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()){
            case R.id.khoa:
                if(item.isChecked()==false) item.setChecked(true);
                else item.setChecked(false);
                if(item.isChecked()==true){
                    //khóa sự kiện vuốt trên viewpager
                    viewPager.disableScroll(true);
                } else viewPager.disableScroll(false);
                break;
            case  R.id.luu:
                Bitmap b = Screenshots.takesScreenShotOfRootView(main);
                LibraryFragment.list.add(b);
                break;
        }
        return true;
    }
}