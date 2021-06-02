package com.nvn.mylife.Service;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.util.Log;
import android.widget.Toast;

import com.nvn.mylife.Util.NotifyUtil;

import java.util.Timer;
import java.util.TimerTask;

public class MyService extends Service {

    @Override
    public void onCreate() {
        startService(new Intent(this, MyService.class));
        Toast.makeText(this, "Service Created", Toast.LENGTH_LONG).show();

        TimerTask timerTask= new TimerTask() {
            @Override
            public void run() {
                Log.i("Services","Running");
            }
        };

        int delay = 5000;
        Timer timer = new Timer("Timer");
        //timer.schedule(timerTask, delay,2000);
        timer.schedule(timerTask, delay);
        NotifyUtil.createNotification(getApplicationContext(),MyService.class);
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }
    @Override
    public boolean onUnbind(Intent intent) {
        return super.onUnbind(intent);
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        return START_STICKY;
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
    }

}
