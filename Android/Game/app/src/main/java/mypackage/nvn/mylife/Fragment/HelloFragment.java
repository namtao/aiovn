package mypackage.nvn.mylife.Fragment;

import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;

import com.nvn.mylife.R;
import pl.droidsonroids.gif.GifImageView;

public class HelloFragment extends Fragment {
    @Nullable
    GifImageView gif;
    ImageView tv,tv2;
    Button btnPlay;
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view=inflater.inflate(R.layout.fragment_hello,container,false);
        gif=view.findViewById(R.id.gif);
        btnPlay=view.findViewById(R.id.btnPlay);
        tv=view.findViewById(R.id.tv);
        tv2=view.findViewById(R.id.tv2);
        gif.setBackgroundResource(R.drawable.gif);
        btnPlay.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getActivity().getSupportFragmentManager().beginTransaction()
                            .replace(R.id.main_content, new GameFragment()).commit();

            }
        });
        return view;
    }
}
