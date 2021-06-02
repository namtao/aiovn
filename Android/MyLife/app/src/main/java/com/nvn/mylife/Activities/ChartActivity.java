package com.nvn.mylife.Activities;

import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;

import com.github.mikephil.charting.charts.BarChart;
import com.github.mikephil.charting.charts.CombinedChart;
import com.github.mikephil.charting.charts.LineChart;
import com.github.mikephil.charting.charts.PieChart;
import com.github.mikephil.charting.data.*;
import com.github.mikephil.charting.data.PieEntry;
import com.nvn.mylife.R;
import com.nvn.mylife.Util.ChartUtil;

import java.util.ArrayList;

public class ChartActivity extends AppCompatActivity {

    PieChart pieChart;
    BarChart barChart;
    LineChart lineChart;
    CombinedChart combinedChart;
    ChartUtil chartUtil = new ChartUtil();

    ArrayList<BarEntry> listBarEntry;
    ArrayList<PieEntry> listPieEntry;
    ArrayList<Entry> listLineEntry;
    ArrayList<Entry> listLineEntry1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chart);

        barChart = findViewById(R.id.barChart);
        pieChart = findViewById(R.id.pieChart);
        lineChart = findViewById(R.id.lineChart);
        combinedChart = findViewById(R.id.combinedChart);

        listBarEntry = new ArrayList<>();
        listPieEntry = new ArrayList<>();
        listLineEntry = new ArrayList<>();
        listLineEntry1 = new ArrayList<>();

        chartUtil.initBarChart(barChart);
        chartUtil.initPieChart(pieChart, listPieEntry);

        chartUtil.initLineChart(lineChart, listLineEntry, listLineEntry1);

        chartUtil.initCombinedChart(combinedChart);

    }
}