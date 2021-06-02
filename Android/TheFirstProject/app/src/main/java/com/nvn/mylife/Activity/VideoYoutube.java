package com.nvn.mylife.Activity;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.widget.Toast;

import com.google.android.youtube.player.YouTubeBaseActivity;
import com.google.android.youtube.player.YouTubeInitializationResult;
import com.google.android.youtube.player.YouTubePlayer;
import com.google.android.youtube.player.YouTubePlayerView;

import com.nvn.mylife.R;

public class VideoYoutube extends YouTubeBaseActivity implements YouTubePlayer.OnInitializedListener {

    public static int i=0;
    public static final String API_KEY="AIzaSyDYLped5gjZun-pb-GzA0scIcreUTRiczg";
    public static final String[] path= {"bNEtI9CMkJs","T-ZFLuOZ0Nc","NyS1_AtTu2k","3M4tJcWXQQE","KZPfVyzE-HU","7AYkkku854c","xvjiPjjbJBI","UxOEyFuN59Y","MtzDqwoLYIo","OE1egLQ15NU"};
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_video_youtube);
        YouTubePlayerView youTubePlayerView= findViewById(R.id.youtube);
        youTubePlayerView.initialize(API_KEY,this);
    }

    @Override
    public void onInitializationSuccess(YouTubePlayer.Provider provider, YouTubePlayer youTubePlayer, boolean b) {
        try{
            youTubePlayer.setPlayerStateChangeListener(playerStateChangeListener);
            youTubePlayer.setPlaybackEventListener(playbackEventListener);

            if(!b){
                youTubePlayer.cueVideo(path[i]);
            }
        } catch (Exception ex){
            Toast.makeText(this, "Cài đặt youtube trước khi xem video!", Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void onInitializationFailure(YouTubePlayer.Provider provider, YouTubeInitializationResult youTubeInitializationResult) {
        Toast.makeText(this, "Please install youtube before watching the video!", Toast.LENGTH_LONG).show();
    }

    private YouTubePlayer.PlayerStateChangeListener playerStateChangeListener= new YouTubePlayer.PlayerStateChangeListener() {
        @Override
        public void onLoading() {

        }

        @Override
        public void onLoaded(String s) {

        }

        @Override
        public void onAdStarted() {

        }

        @Override
        public void onVideoStarted() {

        }

        @Override
        public void onVideoEnded() {

        }

        @Override
        public void onError(YouTubePlayer.ErrorReason errorReason) {

        }
    };

    private YouTubePlayer.PlaybackEventListener playbackEventListener= new YouTubePlayer.PlaybackEventListener() {
        @Override
        public void onPlaying() {

        }

        @Override
        public void onPaused() {

        }

        @Override
        public void onStopped() {

        }

        @Override
        public void onBuffering(boolean b) {

        }

        @Override
        public void onSeekTo(int i) {

        }
    };
}
