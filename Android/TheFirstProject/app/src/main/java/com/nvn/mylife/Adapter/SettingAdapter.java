package com.nvn.mylife.Adapter;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

import com.nvn.mylife.Entities.Setting;
import com.nvn.mylife.R;

public class SettingAdapter extends RecyclerView.Adapter<SettingAdapter.ViewHolderRecycler> {

    Context context;
    List<Setting> list;

    public SettingAdapter(Context context, List<Setting> list) {
        this.context=context;
        this.list=list;
    }


    public class ViewHolderRecycler extends RecyclerView.ViewHolder {
        private ImageView imageView;
        private TextView textView;
        public ViewHolderRecycler( View itemView) {
            super(itemView);
            imageView= (ImageView) itemView.findViewById(R.id.icon_recyclerview);
            textView= itemView.findViewById(R.id.noidung_recyclerview);
        }
    }

    @NonNull
    @Override
    public ViewHolderRecycler onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        View view=LayoutInflater.from(viewGroup.getContext()).inflate(R.layout.item_recyclerview,viewGroup,false);
        return new ViewHolderRecycler(view);
    }

    @Override
    public void onBindViewHolder(ViewHolderRecycler viewHolderRecycler, int i) {
        Setting caiDat= list.get(i);
        viewHolderRecycler.imageView.setImageResource(caiDat.getIcon());
        viewHolderRecycler.textView.setText(caiDat.getContent());
    }

    @Override
    public int getItemCount() {
        return list.size();
    }
}
