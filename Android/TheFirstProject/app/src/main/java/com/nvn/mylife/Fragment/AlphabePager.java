package com.nvn.mylife.Fragment;

import android.media.MediaPlayer;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.speech.tts.TextToSpeech;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Locale;

import com.nvn.mylife.R;
//class của lauout_chucai, code để hiện layout_alphabe
//dùng cho custom adapter
public class AlphabePager extends Fragment {
    private FrameLayout mDrawFrameLayout;
    TextView tvUpperCase,tvLowerCase, tvExample;
    TextToSpeech t1;
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.layout_alphabe,container,false);
        //set hình ảnh cho pager
        String chuin = getArguments().getString("Upper Case" );
        String chuthuong= getArguments().getString("Lower Case");
        String chucai=getArguments().getString("Example");

        tvUpperCase= (TextView) view.findViewById(R.id.chuhoa);
        tvLowerCase= view.findViewById(R.id.chuthuong);
        tvExample=view.findViewById(R.id.tv_vidu);

//        image_chuhoa.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                mediaPlayer = MediaPlayer.create(getContext(),amthanh);
//                mediaPlayer.start();
//            }
//        });
//
//        image_chuthuong.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                mediaPlayer = MediaPlayer.create(getContext(),amthanh);
//                mediaPlayer.start();
//            }
//        });

//        image_chuhoa.setImageDrawable(getResources().getDrawable(chuin));
//        image_chuthuong.setImageDrawable((getResources().getDrawable(chuthuong)));
        tvUpperCase.setText(chuin);
        tvLowerCase.setText(chuthuong);
        tvExample.setText(chucai);

        //TextToSpeed
        t1=new TextToSpeech(getContext(), new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int status) {
                if(status==TextToSpeech.SUCCESS){
                    int rs=t1.setLanguage(Locale.ENGLISH);
                    if(rs==TextToSpeech.LANG_MISSING_DATA||rs==TextToSpeech.LANG_NOT_SUPPORTED){
                        Toast.makeText(getActivity().getApplicationContext(), "Not supported "+Locale.getDefault().getLanguage(), Toast.LENGTH_SHORT).show();
                    } else {
                        t1.setPitch(1.0f);
                        t1.setSpeechRate(1.0f);
                    }
                }
            }
        });

        tvUpperCase.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String toSpeak=tvUpperCase.getText().toString();
                if(Build.VERSION.SDK_INT>=Build.VERSION_CODES.LOLLIPOP){
                    t1.speak(toSpeak,TextToSpeech.QUEUE_FLUSH,null,null);
                } else t1.speak(toSpeak,TextToSpeech.QUEUE_FLUSH,null);
            }
        });

        tvLowerCase.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String toSpeak=tvLowerCase.getText().toString();
                if(Build.VERSION.SDK_INT>=Build.VERSION_CODES.LOLLIPOP){
                    t1.speak(toSpeak,TextToSpeech.QUEUE_FLUSH,null,null);
                } else t1.speak(toSpeak,TextToSpeech.QUEUE_FLUSH,null);
            }
        });

        tvExample.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String toSpeak=tvExample.getText().toString();
                if(Build.VERSION.SDK_INT>=Build.VERSION_CODES.LOLLIPOP){
                    t1.speak(toSpeak,TextToSpeech.QUEUE_FLUSH,null,null);
                } else t1.speak(toSpeak,TextToSpeech.QUEUE_FLUSH,null);
            }
        });
        return view;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
    }

    @Override
    public void onPause() {
        super.onPause();
    }
}