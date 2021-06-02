package com.nvn.mylife.CustomView;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Path;
import android.os.Build;
import android.support.annotation.RequiresApi;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import com.nvn.mylife.Entities.Draw;

public class CustomCanvas extends View {
    //Context context;
    Path netVe;
    Paint butVe;
    int dauBut=10;
    public static int mauHienTai=Color.BLACK;

    List<Draw> paths= new ArrayList<>();
    private ArrayList<Draw> undo = new ArrayList<>();
    public CustomCanvas(Context context) {
        super(context);
        //this.context=context;
        //init();
    }

    public CustomCanvas(Context context, AttributeSet attrs) {
        super(context, attrs);
        init();
    }

    public CustomCanvas(Context context, AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        //init();
    }

    @RequiresApi(api = Build.VERSION_CODES.LOLLIPOP)
    public CustomCanvas(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
        //init();
    }

    @Override
    protected void onDraw(Canvas canvas) {
        canvas.save();
        for(Draw draw:paths){
            butVe.setColor(draw.mauSac);
            butVe.setMaskFilter(null);
            //vẽ lại cái nét vẽ trong list path
            canvas.drawPath(draw.path,butVe);
        }
        canvas.restore();
    }

    @Override
    public boolean onTouchEvent(MotionEvent event) {
        switch (event.getAction()){
            case MotionEvent.ACTION_DOWN:
                netVe = new Path();
                Draw draw= new Draw(mauHienTai,dauBut,netVe);
                paths.add(draw);
                netVe.reset();
                netVe.moveTo(event.getX(),event.getY());
                break;
            case MotionEvent.ACTION_MOVE:
                netVe.lineTo(event.getX(),event.getY());
                break;
            case MotionEvent.ACTION_UP:
                netVe.lineTo(event.getX(),event.getY());
                break;
            default:
                break;
        }
        invalidate();
        return true;
    }

    public void init(){
        butVe= new Paint();
        butVe.setAntiAlias(true);
        butVe.setDither(true);
        butVe.setStrokeWidth(dauBut);//kich thuoc net ve
        butVe.setColor(mauHienTai);
        butVe.setStyle(Paint.Style.STROKE);
        butVe.setStrokeJoin(Paint.Join.ROUND);
        butVe.setXfermode(null);
        butVe.setAlpha(0xff);
    }

        public void undo () {

        if (paths.size() > 0) {

            undo.add(paths.remove(paths.size() - 1));
            invalidate(); // add

        } else {

            Toast.makeText(getContext(), "Không thể quay lại", Toast.LENGTH_LONG).show();

        }

    }

}
