package com.nvn.services;

import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public interface IServices <T, K>{
    List<T> getAll();

    Optional<T> findById(Integer id);

    void insert(T t);

    void update(T t);

    void delete(T t);

    void deleteById(K id);
}
