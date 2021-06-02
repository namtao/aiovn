package com.nvn.mylife.Util;

import android.graphics.Color;

import com.github.mikephil.charting.charts.BarChart;
import com.github.mikephil.charting.charts.CombinedChart;
import com.github.mikephil.charting.charts.LineChart;
import com.github.mikephil.charting.charts.PieChart;
import com.github.mikephil.charting.components.YAxis;
import com.github.mikephil.charting.data.BarData;
import com.github.mikephil.charting.data.BarDataSet;
import com.github.mikephil.charting.data.BarEntry;
import com.github.mikephil.charting.data.BubbleData;
import com.github.mikephil.charting.data.BubbleDataSet;
import com.github.mikephil.charting.data.BubbleEntry;
import com.github.mikephil.charting.data.CandleData;
import com.github.mikephil.charting.data.CandleDataSet;
import com.github.mikephil.charting.data.CandleEntry;
import com.github.mikephil.charting.data.CombinedData;
import com.github.mikephil.charting.data.Entry;
import com.github.mikephil.charting.data.LineData;
import com.github.mikephil.charting.data.LineDataSet;
import com.github.mikephil.charting.data.PieData;
import com.github.mikephil.charting.data.PieDataSet;
import com.github.mikephil.charting.data.PieEntry;
import com.github.mikephil.charting.data.*;
import com.github.mikephil.charting.data.ScatterDataSet;
import com.github.mikephil.charting.interfaces.datasets.ILineDataSet;
import com.github.mikephil.charting.utils.ColorTemplate;

import java.util.ArrayList;

public class ChartUtil {
    private final int count = 12;
    private LineData generateLineData() {

        LineData d = new LineData();

        ArrayList<Entry> entries = new ArrayList<>();

        //set data
        for (int index = 0; index < count; index++)
            entries.add(new Entry(index + 0.5f, getRandom(15, 5)));

        LineDataSet set = new LineDataSet(entries, "Line DataSet");
        set.setColor(Color.rgb(240, 238, 70));
        set.setLineWidth(2.5f);
        set.setCircleColor(Color.rgb(240, 238, 70));
        set.setCircleRadius(5f);
        set.setFillColor(Color.rgb(240, 238, 70));
        set.setMode(LineDataSet.Mode.CUBIC_BEZIER);
        set.setDrawValues(true);
        set.setValueTextSize(10f);
        set.setValueTextColor(Color.rgb(240, 238, 70));

        set.setAxisDependency(YAxis.AxisDependency.LEFT);
        d.addDataSet(set);

        return d;
    }

    private BarData generateBarData() {

        ArrayList<BarEntry> entries1 = new ArrayList<>();
        ArrayList<BarEntry> entries2 = new ArrayList<>();

        for (int index = 0; index < count; index++) {
            entries1.add(new BarEntry(0, getRandom(25, 25)));

            // stacked
            entries2.add(new BarEntry(0, new float[]{getRandom(13, 12), getRandom(13, 12)}));
        }

        BarDataSet set1 = new BarDataSet(entries1, "Bar 1");
        set1.setColor(Color.rgb(60, 220, 78));
        set1.setValueTextColor(Color.rgb(60, 220, 78));
        set1.setValueTextSize(10f);
        set1.setAxisDependency(YAxis.AxisDependency.LEFT);

        BarDataSet set2 = new BarDataSet(entries2, "");
        set2.setStackLabels(new String[]{"Stack 1", "Stack 2"});
        set2.setColors(Color.rgb(61, 165, 255), Color.rgb(23, 197, 255));
        set2.setValueTextColor(Color.rgb(61, 165, 255));
        set2.setValueTextSize(10f);
        set2.setAxisDependency(YAxis.AxisDependency.LEFT);

        float groupSpace = 0.06f;
        float barSpace = 0.02f; // x2 dataset
        float barWidth = 0.45f; // x2 dataset
        // (0.45 + 0.02) * 2 + 0.06 = 1.00 -> interval per "group"

        BarData d = new BarData(set1, set2);
        d.setBarWidth(barWidth);

        // make this BarData object grouped
        d.groupBars(0, groupSpace, barSpace); // start at x = 0

        return d;
    }

    private ScatterData generateScatterData() {

        ScatterData d = new ScatterData();

        ArrayList<Entry> entries = new ArrayList<>();

        for (float index = 0; index < count; index += 0.5f)
            entries.add(new Entry(index + 0.25f, getRandom(10, 55)));

        ScatterDataSet set = new ScatterDataSet(entries, "Scatter DataSet");
        set.setColors(ColorTemplate.MATERIAL_COLORS);
        set.setScatterShapeSize(7.5f);
        set.setDrawValues(false);
        set.setValueTextSize(10f);
        d.addDataSet(set);

        return d;
    }

    private CandleData generateCandleData() {

        CandleData d = new CandleData();

        ArrayList<CandleEntry> entries = new ArrayList<>();

        for (int index = 0; index < count; index += 2)
            entries.add(new CandleEntry(index + 1f, 90, 70, 85, 75f));

        CandleDataSet set = new CandleDataSet(entries, "Candle DataSet");
        set.setDecreasingColor(Color.rgb(142, 150, 175));
        set.setShadowColor(Color.DKGRAY);
        set.setBarSpace(0.3f);
        set.setValueTextSize(10f);
        set.setDrawValues(false);
        d.addDataSet(set);

        return d;
    }

    private BubbleData generateBubbleData() {

        BubbleData bd = new BubbleData();

        ArrayList<BubbleEntry> entries = new ArrayList<>();

        for (int index = 0; index < count; index++) {
            float y = getRandom(10, 105);
            float size = getRandom(100, 105);
            entries.add(new BubbleEntry(index + 0.5f, y, size));
        }

        BubbleDataSet set = new BubbleDataSet(entries, "Bubble DataSet");
        set.setColors(ColorTemplate.VORDIPLOM_COLORS);
        set.setValueTextSize(10f);
        set.setValueTextColor(Color.WHITE);
        set.setHighlightCircleWidth(1.5f);
        set.setDrawValues(true);
        bd.addDataSet(set);

        return bd;
    }

    public void initCombinedChart(CombinedChart combinedChart){
        combinedChart.getDescription().setEnabled(false);
        combinedChart.setBackgroundColor(Color.WHITE);
        combinedChart.setDrawGridBackground(false);
        combinedChart.setDrawBarShadow(false);
        combinedChart.setHighlightFullBarEnabled(false);
        // draw bars behind lines
        combinedChart.setDrawOrder(new com.github.mikephil.charting.charts.CombinedChart.DrawOrder[]{
                com.github.mikephil.charting.charts.CombinedChart.DrawOrder.BAR, com.github.mikephil.charting.charts.CombinedChart.DrawOrder.BUBBLE, com.github.mikephil.charting.charts.CombinedChart.DrawOrder.CANDLE, com.github.mikephil.charting.charts.CombinedChart.DrawOrder.LINE, com.github.mikephil.charting.charts.CombinedChart.DrawOrder.SCATTER
        });

        CombinedData data = new CombinedData();

        data.setData(generateLineData());
        data.setData(generateBarData());
        //data.setData(generateBubbleData());
        //data.setData(generateScatterData());
        //data.setData(generateCandleData());
        //data.setValueTypeface(tfLight);

        combinedChart.setData(data);
        combinedChart.invalidate();
    }

    public ArrayList initBarDataChart(){
        ArrayList<BarEntry> list = new ArrayList<>();
        list.add(new BarEntry(2014, 400));
        list.add(new BarEntry(2015, 300));
        list.add(new BarEntry(2016, 400));
        list.add(new BarEntry(2017, 500));
        list.add(new BarEntry(2018, 400));
        list.add(new BarEntry(2019, 300));
        list.add(new BarEntry(2020, 200));
        list.add(new BarEntry(2021, 100));
        list.add(new BarEntry(2022, 2000));
        list.add(new BarEntry(2023, 900));
        return list;
    }

    private BarData initBarData() {

        ArrayList<BarEntry> entries1 = new ArrayList<>();

        entries1 = initBarDataChart();

        BarDataSet set1 = new BarDataSet(entries1, "Bar 1");
        set1.setColor(Color.rgb(60, 220, 78));
        set1.setValueTextColor(Color.rgb(60, 220, 78));
        set1.setValueTextSize(10f);
        set1.setAxisDependency(YAxis.AxisDependency.LEFT);

        BarData d = new BarData(set1);

        return d;
    }

    public void initBarChart(BarChart barChart){

        barChart.setData(initBarData());
        barChart.getDescription().setText("Bar chart");
        barChart.animateY(2000);
        barChart.setHighlightFullBarEnabled(true);
    }

    public void initPieDataChart(ArrayList<PieEntry> list){
        list.add(new PieEntry(400  , "T1"));
        list.add(new PieEntry(400  , "T2"));
        list.add(new PieEntry(400  , "T3"));
        list.add(new PieEntry(400  , "T4"));
        list.add(new PieEntry(400  , "T5"));
        list.add(new PieEntry(400  , "T6"));
        list.add(new PieEntry(400  , "T7"));
        list.add(new PieEntry(400  , "T8"));
        list.add(new PieEntry(400  , "T9"));
        list.add(new PieEntry(400  , "T10"));
        list.add(new PieEntry(400  , "T11"));
        list.add(new PieEntry(400  , "T12"));
    }

    public void initPieChart(PieChart pieChart, ArrayList<PieEntry> list){
        initPieDataChart(list);

        PieDataSet dataSet= new PieDataSet(list, "Tháng");
        dataSet.setColors(ColorTemplate.COLORFUL_COLORS);
        dataSet.setValueTextColor(Color.BLACK);
        dataSet.setValueTextSize(16f);

        PieData data =  new PieData(dataSet);

        pieChart.setData(data);
        pieChart.getDescription().setEnabled(false);
        pieChart.setCenterText("Pie Chart");

        pieChart.animate();
        pieChart.animateY(2000);
    }

    public void initLineDataChart(ArrayList<Entry> list, ArrayList<Entry> list1){
        list.add(new Entry(2014, 400));
        list.add(new Entry(2015, 300));
        list.add(new Entry(2016, 400));
        list.add(new Entry(2017, 500));
        list.add(new Entry(2018, 400));
        list.add(new Entry(2019, 300));
        list.add(new Entry(2020, 200));
        list.add(new Entry(2021, 100));
        list.add(new Entry(2022, 2000));
        list.add(new Entry(2023, 900));

        list1.add(new Entry(2013,300));
        list1.add(new Entry(2014,200));
        list1.add(new Entry(2015,500));
    }

    public void initLineChart(LineChart lineChart, ArrayList<Entry> list, ArrayList<Entry> list1){
        initLineDataChart(list, list1);
        LineDataSet dataSet= new LineDataSet(list, "Data 1");
        LineDataSet dataSet1= new LineDataSet(list1, "Data 2");
        //multi dataset
        ArrayList<ILineDataSet> dataSets = new ArrayList<>();
        dataSets.add(dataSet);
        dataSets.add(dataSet1);

        //dataSet.setColors(ColorTemplate.COLORFUL_COLORS);
        dataSet.setValueTextColor(Color.BLACK);
        dataSet.setValueTextSize(16f);

        LineData data =  new LineData(dataSets);

        lineChart.setData(data);
        lineChart.getDescription().setText("Line Chart");

        lineChart.animate();
        lineChart.animateY(2000);
    }

    protected float getRandom(float range, float start) {
        return (float) (Math.random() * range) + start;
    }
}
