package nvn.game.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.drawable.Drawable;
import android.media.MediaPlayer;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.speech.tts.TextToSpeech;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import nvn.game.myapplication.R;

import java.util.Locale;
import java.util.Random;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    ImageView so1,so2,so3,so4,so5,so6,so7,so8,so9;

    TextToSpeech t1;
    //Random random;
    TextView mang,diem;
    AsynTask asynTask;
    Button btnBatDau,btnKetThuc;
    int somang=10,sodiem=0;
    Handler handler;
    MediaPlayer nhacNen,nhacKetThuc;
    RelativeLayout layout;
    int so;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        t1=new TextToSpeech(getApplicationContext(), new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int status) {
                if(status == TextToSpeech.SUCCESS) {
                    t1.setLanguage(Locale.UK);
                    t1.speak("Hello", TextToSpeech.QUEUE_ADD, null);
                }
            }
        });


        so1=findViewById(R.id.so1);
        so2=findViewById(R.id.so2);
        so3=findViewById(R.id.so3);
        so4=findViewById(R.id.so4);
        so5=findViewById(R.id.so5);
        so6=findViewById(R.id.so6);
        so7=findViewById(R.id.so7);
        so8=findViewById(R.id.so8);
        so9=findViewById(R.id.so9);
        ImageView[] list={so1,so2,so3,so4,so5,so6,so7,so8,so9};
        mang=findViewById(R.id.tv_mang);
        diem=findViewById(R.id.tv_diem);
        btnBatDau=findViewById(R.id.batdau);
        btnKetThuc=findViewById(R.id.ketthuc);
        layout=findViewById(R.id.fragment_batdau);


        so1.setOnClickListener(this);
        so2.setOnClickListener(this);
        so3.setOnClickListener(this);
        so4.setOnClickListener(this);
        so5.setOnClickListener(this);
        so6.setOnClickListener(this);
        so7.setOnClickListener(this);
        so8.setOnClickListener(this);
        so9.setOnClickListener(this);


        init();
        btnBatDau.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                asynTask= new AsynTask();
                asynTask.execute();
                mang.setText(""+somang);
                diem.setText(""+sodiem);
            }
        });

        btnKetThuc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                thongBao();
                sodiem=0;
                somang=10;
            }
        });
    }

    public void thongBao(){
        somang=10;
        sodiem=0;

//        asynTask.cancel(true);
    }
    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.so1:
                if(so==0) {
                    so1.setBackgroundResource(R.drawable.bucminh);
                    sodiem+=10;
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so2:
                if(so==1) {
                    sodiem+=10;
                    so2.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so3:
                if(so==2) {
                    sodiem+=10;
                    so3.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so4:
                if(so==3) {
                    sodiem+=10;
                    so4.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so5:
                if(so==4) {
                    sodiem+=10;
                    so5.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so6:
                if(so==5) {
                    sodiem+=10;
                    so6.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so7:
                if(so==6) {
                    sodiem+=10;
                    so7.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so8:
                if(so==7) {
                    sodiem+=10;
                    so8.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so9:
                if(so==8) {
                    sodiem+=10;
                    so9.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
        }
    }

    public void init(){
        so1.setBackgroundResource(R.drawable.trang);
        so2.setBackgroundResource(R.drawable.trang);
        so3.setBackgroundResource(R.drawable.trang);
        so4.setBackgroundResource(R.drawable.trang);
        so5.setBackgroundResource(R.drawable.trang);
        so6.setBackgroundResource(R.drawable.trang);
        so7.setBackgroundResource(R.drawable.trang);
        so8.setBackgroundResource(R.drawable.trang);
        so9.setBackgroundResource(R.drawable.trang);
    }


    class AsynTask extends AsyncTask<Void,Void,Void> {

        //thực hiện các công việc ban đầu
        @Override
        protected void onPreExecute() {
            if(somang>0){
                Random random= new Random();
                so=random.nextInt(9);
                switch (so){
                    case 0:
                        so1.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so1.setBackgroundResource(R.drawable.trang);
                            }
                        },800);
                        break;
                    case 1:
                        so2.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so2.setBackgroundResource(R.drawable.trang);
                            }
                        },800);
                        break;
                    case 2:
                        so3.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so3.setBackgroundResource(R.drawable.trang);
                            }
                        },800);
                        break;
                    case 3:
                        so4.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so4.setBackgroundResource(R.drawable.trang);
                            }
                        },800);
                        break;
                    case 4:
                        so5.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so5.setBackgroundResource(R.drawable.trang);
                            }
                        },800);
                        break;
                    case 5:
                        so6.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so6.setBackgroundResource(R.drawable.trang);
                            }
                        },800);
                        break;
                    case 6:
                        so7.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so7.setBackgroundResource(R.drawable.trang);
                            }
                        },800);
                        break;
                    case 7:
                        so8.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so8.setBackgroundResource(R.drawable.trang);
                            }
                        },800);
                        break;
                    case 8:
                        so9.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so9.setBackgroundResource(R.drawable.trang);
                            }
                        },800);
                        break;
                }
            } else {
                asynTask.cancel(true);
                thongBao();
            }
            super.onPreExecute();
        }

        //sau khi thực hiện xong task
        @Override
        protected void onPostExecute(Void aVoid) {
            if(somang>0){
                if(asynTask!=null) {
//                    asynTask.cancel(true);
                    asynTask= new AsynTask();
                    asynTask.execute();
                } else {
                    asynTask= new AsynTask();
                    asynTask.execute();
                }
            } else {
//                asynTask.cancel(true);
                thongBao();
            }
        }

        //quá trình thực hiện tác vụ được kiểm soát
        @Override
        protected void onProgressUpdate(Void... values) {
            super.onProgressUpdate(values);
        }

        //thực hiện task dài
        @Override
        protected Void doInBackground(Void... voids) {
            try{
                Thread.sleep(800);
            } catch (InterruptedException e){
                e.printStackTrace();
            }
            return null;
        }
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
    }

    public Boolean SoSanhAnh(ImageView v){
        int id = getResources().getIdentifier("@drawable/mouse", null, getApplication().getPackageName());

        Drawable.ConstantState constantState;

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
            constantState = getApplication().getResources().getDrawable(id,getApplication().getTheme()).getConstantState();
        } else {
            constantState = getApplication().getResources().getDrawable(id).getConstantState();
        }

        if (v.getBackground().getConstantState() == constantState) {
            return true;
        }

        return false;
    }
}