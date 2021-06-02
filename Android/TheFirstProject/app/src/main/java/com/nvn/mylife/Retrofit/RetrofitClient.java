package com.nvn.mylife.Retrofit;


import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.util.concurrent.TimeUnit;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

//cấu hình RetrofitClient, gửi request lên server
public class RetrofitClient {
    public static Retrofit retrofit = null;
    public static Retrofit getClient(String baseurl){
        OkHttpClient builder= new OkHttpClient.Builder().connectTimeout(10000,TimeUnit.MILLISECONDS).retryOnConnectionFailure(true).build();

        Gson gson= new GsonBuilder().setLenient().create();

        retrofit= new Retrofit.Builder().baseUrl(baseurl).client(builder).addConverterFactory(GsonConverterFactory.create(gson)).build();

        return retrofit;
    }
}
