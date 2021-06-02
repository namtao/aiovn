package com.nvn.mylife.Services;

import android.app.Notification;
import android.app.Service;
import android.content.Intent;
import android.media.MediaPlayer;
import android.os.IBinder;
import android.support.annotation.Nullable;
import android.util.Log;
import android.widget.Toast;

import com.nvn.mylife.Activity.MainActivity;
import com.nvn.mylife.R;
import com.nvn.mylife.Util.NotificationUtil;

import java.util.Calendar;
import java.util.Date;
import java.util.Timer;
import java.util.TimerTask;

public class NotifyService extends Service {

    MediaPlayer alarm;
    @Override
    public void onCreate() {
        startService(new Intent(this, NotifyService.class));
        Toast.makeText(this, "Service Created", Toast.LENGTH_LONG).show();
        NotificationUtil.createNotification(getApplicationContext(), MainActivity.class);

        //schedule
        TimerTask myTask = new TimerTask() {
            @Override
            public void run() {
                //alarm = MediaPlayer.create(getApplicationContext(), R.raw.alarm);
                //alarm.start();
                Log.i("Timer",Calendar.getInstance().getTime().toString()+"");
            }
        };
        Timer timer = new Timer();
        Calendar calendar = Calendar.getInstance();
        calendar.set(Calendar.HOUR_OF_DAY, 12);
        calendar.set(Calendar.MINUTE, 50);
        calendar.set(Calendar.SECOND, 0);
        calendar.set(Calendar.MILLISECOND, 0);
        Date dateSchedule = calendar.getTime();
        long period = 24 * 60 * 60 * 1000;

        //timer.schedule(myTask, dateSchedule, period);
        timer.schedule(myTask,5000);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
/*        stopService(new Intent(this, Notification.class));
        Toast.makeText(this, "Service Stopped", Toast.LENGTH_LONG).show();
        try {
            Thread.sleep(10000);
            startService(new Intent(this, NotifyService.class));
        } catch (InterruptedException e) {
            e.printStackTrace();
        }*/
    }

    @Override
    public boolean onUnbind(Intent intent) {
        return super.onUnbind(intent);
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        return START_STICKY;
    }

    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

}
