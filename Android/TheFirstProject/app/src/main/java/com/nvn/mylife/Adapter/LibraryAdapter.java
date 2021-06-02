package com.nvn.mylife.Adapter;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Bitmap;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import java.util.List;

import com.nvn.mylife.Fragment.LibraryFragment;
import com.nvn.mylife.R;

public class LibraryAdapter extends RecyclerView.Adapter<LibraryAdapter.ViewHolder>{
    List<Bitmap> list_thuvien;
    Context context;

    public LibraryAdapter(Context context, List<Bitmap> list_thuvien) {
        this.context=context;
        this.list_thuvien = list_thuvien;
    }

    //set layout của từng item trong recycleview
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        LayoutInflater layoutInflater = LayoutInflater.from(viewGroup.getContext());
        View view=layoutInflater.inflate(R.layout.item_library,viewGroup,false);
        return new ViewHolder(view);
    }

    //set sự kiện và các thuộc tính cần thiết
    @Override
    public void onBindViewHolder(final ViewHolder viewHolder, int i) {
        viewHolder.img_thuvien.setImageBitmap(list_thuvien.get(i));
        viewHolder.itemView.setOnLongClickListener(new View.OnLongClickListener() {
            @Override
            public boolean onLongClick(View v) {
                AlertDialog.Builder builder = new AlertDialog.Builder(v.getContext());
                builder.setTitle("Thông báo");
                builder.setMessage("Bạn có muốn xóa không?");
                builder.setCancelable(false);
                builder.setPositiveButton("Thoát", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.dismiss();
                    }
                });
                builder.setNegativeButton("Xóa", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        //Toast.makeText(, "Đã xóa", Toast.LENGTH_SHORT).show();
                        LibraryFragment.list.remove(viewHolder.getAdapterPosition());
                        notifyDataSetChanged();
                    }
                });
                AlertDialog alertDialog = builder.create();
                alertDialog.show();
                return true;
            }
        });
    }

    //kích thước của mảng
    @Override
    public int getItemCount() {
        return list_thuvien.size();
    }

    //các thành phần của recycleview
    public class ViewHolder extends RecyclerView.ViewHolder {

        public ImageView img_thuvien;

        public ViewHolder(View itemView) {
            super(itemView);
            img_thuvien = itemView.findViewById(R.id.imagethuvien);
        }
    }
}
