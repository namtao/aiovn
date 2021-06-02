package com.nvn.mylife.Fragment;

import android.media.MediaPlayer;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import com.eftimoff.viewpagertransformers.DepthPageTransformer;

import java.util.Timer;

import com.nvn.mylife.Adapter.AlphabeAdapter;
import com.nvn.mylife.R;
//class của fragment_alphabe
//fragment có viewpager-> cần viewpager
//viewpager cần 1 adapter truyền vào nên cần custom 1 adapter
public class AlphabeFragment extends Fragment {
    private ViewPager viewPager;
    private AlphabeAdapter alphabeAdapter;
    Timer timer;
    Button btnBottom;
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        super.onCreateView(inflater, container, savedInstanceState);
        View view= inflater.inflate(R.layout.fragment_alphabe,container,false);
        viewPager= (ViewPager)view.findViewById(R.id.vp_chucai);
        alphabeAdapter = new AlphabeAdapter(getActivity().getSupportFragmentManager(),getContext());
        viewPager.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {
            @Override
            public void onPageScrolled(int i, float v, int i1) {

            }

            @Override
            public void onPageSelected(int i) {
                /*if(mediaPlayer!=null) mediaPlayer.stop();
                mediaPlayer= MediaPlayer.create(getActivity(),mAudio[i]);
                mediaPlayer.start();*/
            }

            @Override
            public void onPageScrollStateChanged(int i) {

            }
        });
        viewPager.setPageTransformer(true, new DepthPageTransformer());
        viewPager.setAdapter(alphabeAdapter);
        //thời gian chuyển màn hình của viewpager
//        TimerTask timerTask = new TimerTask() {
//            @Override
//            public void run() {
//                viewPager.post(new Runnable(){
//
//                    @Override
//                    public void run() {
//                        viewPager.setCurrentItem((viewPager.getCurrentItem()+1)%mAudio.length);
//                    }
//                });
//            }
//        };
//        timer = new Timer();
//        //scheduleAtFixedRate: thời gian bắt đầu +  số lần lặp* thời gian delay
//        //timer.scheduleAtFixedRate(timerTask,0,10000);
//        //schedule: lần lặp cuối + delay
//        timer.schedule(timerTask, 0, 15000);
        return view;
    }

        @Override
    public void onDestroy() {
        super.onDestroy();
    }
}