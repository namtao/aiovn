package com.nvn.mylife.Service;

import com.nvn.mylife.Model.Todos;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
public interface APIService {
    @GET("/todos")
    Call<List<Todos>> getTodos();
}
