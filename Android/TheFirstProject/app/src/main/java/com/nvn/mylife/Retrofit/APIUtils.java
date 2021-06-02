package com.nvn.mylife.Retrofit;

//cung cấp dường dẫn
public class APIUtils {
    public static final String BaseUrl="http://192.168.16.107:29/androidwebservice/";

    //nhận và gửi dữ liệu đi
    public static DataClient getData(){
        return RetrofitClient.getClient(BaseUrl).create(DataClient.class);
    }
}
