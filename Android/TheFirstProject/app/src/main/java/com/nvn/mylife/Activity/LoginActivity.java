package com.nvn.mylife.Activity;

import android.app.ActivityManager;
import android.content.Context;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

import com.google.android.gms.auth.api.Auth;
import com.google.android.gms.auth.api.signin.GoogleSignInOptions;
import com.google.android.gms.auth.api.signin.GoogleSignInResult;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.SignInButton;
import com.google.android.gms.common.api.GoogleApiClient;

import com.nvn.mylife.R;
import com.nvn.mylife.Services.NotifyService;
import com.nvn.mylife.Util.ServiceUtil;

import pl.droidsonroids.gif.GifImageView;

public class LoginActivity extends AppCompatActivity implements GoogleApiClient.OnConnectionFailedListener {

    GoogleApiClient googleApiClient;
    SignInButton signInButton;

    GifImageView gif;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DEFAULT_SIGN_IN).requestEmail().build();
        googleApiClient = new GoogleApiClient.Builder(this).enableAutoManage(this, this).addApi(Auth.GOOGLE_SIGN_IN_API, gso).build();

        //hide action bar
        this.getSupportActionBar().hide();
        //button default in google
        //signInButton= findViewById(R.id.btnGg);
        gif = findViewById(R.id.gifimage);
        gif.setBackgroundResource(R.drawable.pikachu);
        //signInButton.setSize(SignInButton.SIZE_WIDE);
        //signInButton.setColorScheme(SignInButton.COLOR_DARK);
        gif.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = Auth.GoogleSignInApi.getSignInIntent(googleApiClient);
                startActivityForResult(intent, 777);
            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == 777) {
            GoogleSignInResult result = Auth.GoogleSignInApi.getSignInResultFromIntent(data);
            handleSignInResult(result);
        }
    }

    private void handleSignInResult(GoogleSignInResult result) {
        if (result.isSuccess()) {
            if (!ServiceUtil.isMyServiceRunning(getApplicationContext(), NotifyService.class)) {
                startService(new Intent(this, NotifyService.class));
            }
            Intent intent = new Intent(this, MainActivity.class);
            startActivity(intent);
            //finish();
        } else {
            Toast.makeText(this, "Login fail!!!", Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void onConnectionFailed(@NonNull ConnectionResult connectionResult) {
        Toast.makeText(this, "Login fail!!!", Toast.LENGTH_SHORT).show();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
    }

    @Override
    protected void onStop() {
        super.onStop();
        //Toast.makeText(this, "Stop login", Toast.LENGTH_SHORT).show();
    }
}
