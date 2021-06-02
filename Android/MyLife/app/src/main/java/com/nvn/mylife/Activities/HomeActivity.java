package com.nvn.mylife.Activities;

import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.Spinner;
import android.widget.Toast;

import com.github.mikephil.charting.charts.CombinedChart;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.nvn.mylife.R;
import com.nvn.mylife.Util.ChartUtil;

import java.util.ArrayList;
import java.util.List;

public class HomeActivity extends AppCompatActivity implements  View.OnClickListener {

    FloatingActionButton fab;
    CombinedChart combinedChart;
    ChartUtil chartUtil = new ChartUtil();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
        fab= findViewById(R.id.fab);
        fab.setOnClickListener(this);

        combinedChart = findViewById(R.id.combinedChart);


        chartUtil.initCombinedChart(combinedChart);
    }


    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.fab:
                final AlertDialog.Builder aBuilder = new AlertDialog.Builder(this);
                //ConstraintLayout view2 = (ConstraintLayout)findViewById(R.id.view);
                //view2.setVisibility(View.VISIBLE);
                View view = getLayoutInflater().inflate(R.layout.layout_dialog, null);
                aBuilder.setTitle("Thông tin");
                //aBuilder.setMessage("Chọn loại chi tiêu");
                final Spinner spinner = view.findViewById(R.id.spinner);
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item,getResources().getStringArray(R.array.categories));
                adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner.setAdapter(adapter);

                aBuilder.setView(view);
                aBuilder.setNegativeButton("Cancel",new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        aBuilder.create().dismiss();
                    }
                });
                aBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        if(spinner.getSelectedItem().toString().equalsIgnoreCase("Chi tiêu")){
                            Toast.makeText(HomeActivity.this, "Chi tiêu", Toast.LENGTH_SHORT).show();
                        } else Toast.makeText(HomeActivity.this, "Thu nhập", Toast.LENGTH_SHORT).show();
                    }
                });

                Dialog dialog = aBuilder.create();
                dialog.setCanceledOnTouchOutside(false);
                dialog.show();
        }
    }
}