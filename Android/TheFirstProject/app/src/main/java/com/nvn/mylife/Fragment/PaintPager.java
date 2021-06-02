package com.nvn.mylife.Fragment;

import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;

import com.nvn.mylife.CustomView.CustomCanvas;
import com.nvn.mylife.R;
public class PaintPager extends Fragment implements View.OnClickListener{
    ImageView maudo,vang,cam,xanhduongdam,xanhduong,xanhnuocbien,den,hong,nau,xanhlacay,xanhlama,tim;
    CustomCanvas ds_nen;
    Button btnUndo;
    LinearLayout linearLayout;
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.layout_paint,container,false);
        int nen = getArguments().getInt("Image", 0);
        ds_nen = view.findViewById(R.id.giayve);
        btnUndo=view.findViewById(R.id.btnredo);
        linearLayout= view.findViewById(R.id.mauto);

        maudo=view.findViewById(R.id.maudo);
        vang=view.findViewById(R.id.vang);
        cam=view.findViewById(R.id.cam);
        xanhduongdam=view.findViewById(R.id.xanhduongdam);
        xanhduong=view.findViewById(R.id.xanhduong);
        xanhnuocbien=view.findViewById(R.id.xanhnuocbien);
        den=view.findViewById(R.id.den);
        hong=view.findViewById(R.id.hong);
        nau=view.findViewById(R.id.nau);
        xanhlacay=view.findViewById(R.id.xanhlacay);
        xanhlama=view.findViewById(R.id.xanhlama);
        tim=view.findViewById(R.id.tim);

        maudo.setOnClickListener(this);
        vang.setOnClickListener(this);
        cam.setOnClickListener(this);
        xanhduongdam.setOnClickListener(this);
        xanhduong.setOnClickListener(this);
        xanhnuocbien.setOnClickListener(this);
        den.setOnClickListener(this);
        hong.setOnClickListener(this);
        nau.setOnClickListener(this);
        xanhlacay.setOnClickListener(this);
        xanhlama.setOnClickListener(this);
        tim.setOnClickListener(this);
        btnUndo.setOnClickListener(this);

        ds_nen.setBackgroundResource(nen);
        return view;
    }
    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.maudo:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.maudo);
                break;
            case R.id.vang:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.vang);
                break;
            case R.id.cam:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.cam);
                break;
            case R.id.xanhduongdam:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.xanhduongdam);
                break;
            case R.id.xanhduong:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.xanhduong);
                break;
            case R.id.xanhnuocbien:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.xanhnuocbien);
                break;
            case R.id.den:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.den);
                break;
            case R.id.hong:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.hong);
                break;
            case R.id.nau:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.nau);
                break;
            case R.id.xanhlacay:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.xanhlacay);
                break;
            case R.id.xanhlama:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.xanhlama);
                break;
            case R.id.tim:
                CustomCanvas.mauHienTai=getResources().getColor(R.color.tim);
                break;
            case R.id.btnredo:
                ds_nen.undo();
                break;
        }
    }
}