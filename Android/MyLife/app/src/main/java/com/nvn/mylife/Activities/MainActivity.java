package com.nvn.mylife.Activities;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.speech.tts.TextToSpeech;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import com.nvn.mylife.Model.Todos;
import com.nvn.mylife.R;
import com.nvn.mylife.Service.APIClient;
import com.nvn.mylife.Service.APIService;
import com.nvn.mylife.Service.MyService;

import java.util.List;
import java.util.Locale;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class MainActivity extends AppCompatActivity {

    APIService apiService;
    private static String URL_GET_PRODUCT = "https://jsonplaceholder.typicode.com/todos/1/";
    private static Retrofit retrofit = null;
    TextToSpeech t1;

    Button btnGet;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        //startService(new Intent(this, MyService.class));

        textToSpeed();
        btnGet = findViewById(R.id.btnGet);
        btnGet.setOnClickListener(v -> getTodos());
        apiService = new APIClient().getClient(retrofit, URL_GET_PRODUCT).create(APIService.class);
        //finish();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
    }

    public void getTodos() {
        Call<List<Todos>> call = apiService.getTodos();
        call.enqueue(new Callback<List<Todos>>() {
            @Override
            public void onResponse(Call<List<Todos>> call, Response<List<Todos>> response) {
                Log.i("onResponse", "onResponse" + response.body());
            }

            @Override
            public void onFailure(Call<List<Todos>> call, Throwable t) {
                Log.i("onFailure", "onFailure" + t.getLocalizedMessage());
            }
        });
    }

    public void textToSpeed(){
        t1 = new TextToSpeech(getApplicationContext(), status -> {
            if(status == TextToSpeech.SUCCESS){
                int rs = t1.setLanguage(Locale.ENGLISH);
                if(rs == TextToSpeech.LANG_MISSING_DATA||rs==TextToSpeech.LANG_NOT_SUPPORTED){
                    Toast.makeText(MainActivity.this, "Not supported "+ Locale.getDefault().getLanguage(), Toast.LENGTH_SHORT).show();
                } else {
                    t1.setPitch(1.0f);
                    t1.setSpeechRate(1.0f);
                }
            } else Toast.makeText(MainActivity.this, "Not working!", Toast.LENGTH_SHORT).show();
        });

        String toSpeak= "How are you?";
        t1.speak(toSpeak,TextToSpeech.QUEUE_FLUSH,null,null);
    }
}