package com.nvn.mylife.Fragment;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.graphics.drawable.Drawable;
import android.media.MediaPlayer;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import java.util.Random;

import com.nvn.mylife.R;

public class GameFragment extends Fragment implements View.OnClickListener{
    ImageView so1,so2,so3,so4,so5,so6,so7,so8,so9;

    //Random random;
    TextView mang,diem;
    AsynTask asynTask;
    Button btnBatDau,btnKetThuc;
    int somang=10,sodiem=0;
    Handler handler;
    MediaPlayer nhacNen,nhacDung,nhacKetThuc,nhacSai;
    RelativeLayout layout;
    @Nullable
    @Override
    public View onCreateView(@NonNull final LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view= inflater.inflate(R.layout.fragment_game,container,false);

        so1=view.findViewById(R.id.so1);
        so2=view.findViewById(R.id.so2);
        so3=view.findViewById(R.id.so3);
        so4=view.findViewById(R.id.so4);
        so5=view.findViewById(R.id.so5);
        so6=view.findViewById(R.id.so6);
        so7=view.findViewById(R.id.so7);
        so8=view.findViewById(R.id.so8);
        so9=view.findViewById(R.id.so9);
        ImageView[] list={so1,so2,so3,so4,so5,so6,so7,so8,so9};
        mang=view.findViewById(R.id.tv_mang);
        diem=view.findViewById(R.id.tv_diem);
        btnBatDau=view.findViewById(R.id.batdau);
        btnKetThuc=view.findViewById(R.id.ketthuc);
        layout=view.findViewById(R.id.fragment_batdau);


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

                if(nhacKetThuc!=null) nhacKetThuc.stop();

                if(nhacNen==null) {
                    nhacNen = MediaPlayer.create(getActivity(),R.raw.nhacnen);
                    nhacNen.start();
                    nhacNen.setLooping(true);
                }
            }
        });

        btnKetThuc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                thongBao(v);
                sodiem=0;
                somang=10;
                if(nhacKetThuc!=null) nhacKetThuc.stop();

                if(nhacKetThuc==null) {
                    nhacKetThuc = MediaPlayer.create(getActivity(),R.raw.fail);
                    nhacKetThuc.start();
                    if(nhacNen!=null) nhacNen.stop();
                }
            }
        });
        return view;
    }

    public void thongBao(View v){
        asynTask.cancel(true);
        AlertDialog.Builder builder = new AlertDialog.Builder(v.getContext());
        builder.setTitle("Chúc mừng");
        builder.setMessage("Điểm của bạn là: "+sodiem);
        //phải kích vào nút
        builder.setCancelable(false);
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                nhacNen.stop();
                dialogInterface.dismiss();
            }
        });
        AlertDialog alertDialog = builder.create();
        alertDialog.show();
        somang=10;
        sodiem=0;
    }
    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.so1:
                if(SoSanhAnh((ImageView) v)) {
                    so1.setBackgroundResource(R.drawable.bucminh);
                    sodiem+=10;
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so2:
                if(SoSanhAnh((ImageView) v)) {
                    sodiem+=10;
                    so2.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so3:
                if(SoSanhAnh((ImageView) v)) {
                    sodiem+=10;
                    so3.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so4:
                if(SoSanhAnh((ImageView) v)) {
                    sodiem+=10;
                    so4.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so5:
                if(SoSanhAnh((ImageView) v)) {
                    sodiem+=10;
                    so5.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so6:
                if(SoSanhAnh((ImageView) v)) {
                    sodiem+=10;
                    so6.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so7:
                if(SoSanhAnh((ImageView) v)) {
                    sodiem+=10;
                    so7.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so8:
                if(SoSanhAnh((ImageView) v)) {
                    sodiem+=10;
                    so8.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
            case R.id.so9:
                if(SoSanhAnh((ImageView) v)) {
                    sodiem+=10;
                    so9.setBackgroundResource(R.drawable.bucminh);
                } else somang--;
                mang.setText(""+somang);
                diem.setText(""+sodiem);
                break;
        }
    }

    public void init(){
        so1.setBackgroundResource(R.drawable.nentrang);
        so2.setBackgroundResource(R.drawable.nentrang);
        so3.setBackgroundResource(R.drawable.nentrang);
        so4.setBackgroundResource(R.drawable.nentrang);
        so5.setBackgroundResource(R.drawable.nentrang);
        so6.setBackgroundResource(R.drawable.nentrang);
        so7.setBackgroundResource(R.drawable.nentrang);
        so8.setBackgroundResource(R.drawable.nentrang);
        so9.setBackgroundResource(R.drawable.nentrang);
    }


    class AsynTask extends AsyncTask<Void,Void,Void> {

        //thực hiện các công việc ban đầu
        @Override
        protected void onPreExecute() {
            if(somang>0){
                Random random= new Random();
                int so=random.nextInt(9);
                switch (so){
                    case 0:
                        so1.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so1.setBackgroundResource(R.drawable.nentrang);
                            }
                        },800);
                        break;
                    case 1:
                        so2.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so2.setBackgroundResource(R.drawable.nentrang);
                            }
                        },800);
                        break;
                    case 2:
                        so3.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so3.setBackgroundResource(R.drawable.nentrang);
                            }
                        },800);
                        break;
                    case 3:
                        so4.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so4.setBackgroundResource(R.drawable.nentrang);
                            }
                        },800);
                        break;
                    case 4:
                        so5.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so5.setBackgroundResource(R.drawable.nentrang);
                            }
                        },800);
                        break;
                    case 5:
                        so6.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so6.setBackgroundResource(R.drawable.nentrang);
                            }
                        },800);
                        break;
                    case 6:
                        so7.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so7.setBackgroundResource(R.drawable.nentrang);
                            }
                        },800);
                        break;
                    case 7:
                        so8.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so8.setBackgroundResource(R.drawable.nentrang);
                            }
                        },800);
                        break;
                    case 8:
                        so9.setBackgroundResource(R.drawable.mouse);
                        handler= new Handler();
                        handler.postDelayed(new Runnable() {
                            @Override
                            public void run() {
                                so9.setBackgroundResource(R.drawable.nentrang);
                            }
                        },800);
                        break;
                }
            } else {
                asynTask.cancel(true);
                thongBao(getView());
            }
            super.onPreExecute();
        }

        //sau khi thực hiện xong task
        @Override
        protected void onPostExecute(Void aVoid) {
            if(somang>0){
                if(asynTask!=null) {
                    asynTask.cancel(true);
                    asynTask= new AsynTask();
                    asynTask.execute();
                } else {
                    asynTask= new AsynTask();
                    asynTask.execute();
                }
            } else {
                asynTask.cancel(true);
                thongBao(getView());
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
        if(nhacKetThuc!=null) nhacKetThuc.stop();
        if(nhacNen!=null) nhacNen.stop();
    }

    Drawable.ConstantState constantState;
    public Boolean SoSanhAnh(ImageView v){
        int id= getResources().getIdentifier("@drawable/mouse", null, getContext().getPackageName());

        Drawable.ConstantState constantState;

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
            constantState = getContext().getResources().getDrawable(id,getContext().getTheme()).getConstantState();
        } else {
            constantState = getContext().getResources().getDrawable(id).getConstantState();
        }

        if (v.getBackground().getConstantState() == constantState) {
            return true;
        }

        return false;
    }
}
