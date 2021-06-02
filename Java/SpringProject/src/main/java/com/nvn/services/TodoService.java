package com.nvn.services;

import com.nvn.entities.Todos;
import com.nvn.repository.ITodoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;


@Service
public class TodoService implements IServices<Todos, Integer> {
    @Autowired
    ITodoRepository todoRepository;
    @Override
    public List<Todos> getAll() {
        return todoRepository.findAll();
    }

    @Override
    public Optional<Todos> findById(Integer id) {
        return todoRepository.findById(id);
    }

    @Override
    public void insert(Todos todos) {
        todoRepository.save(todos);
    }

    @Override
    public void update(Todos todos) {
        todoRepository.save(todos);
    }

    @Override
    public void delete(Todos todos) {

    }

    @Override
    public void deleteById(Integer id) {
        todoRepository.deleteById(id);
    }
}
