package com.nvn.api;

import java.util.List;
import java.util.Optional;

import com.nvn.services.IServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.nvn.entities.Todos;

@RestController
@RequestMapping("/api/")
public class TodosAPI {

    @Qualifier("todoService")
    @Autowired
    IServices<Todos, Integer> todoService;

    @GetMapping(value = "todos", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<List<Todos>> todos() {
        return new ResponseEntity<>(todoService.getAll(), HttpStatus.OK);
    }

    @GetMapping(value = "/todos/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
    public  ResponseEntity<Optional<Todos>> findById(@PathVariable int id){
        return new ResponseEntity<>(todoService.findById(id), HttpStatus.OK);
    }

    @PostMapping(value = "insert", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Void> insert(@RequestBody Todos todos) {
        todoService.insert(todos);
        return new ResponseEntity<Void>(HttpStatus.CREATED);
    }

    @PutMapping(value = "update/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Void> update(@RequestBody Todos todos, @PathVariable int id){
        todos.setId(id);
        todoService.update(todos);
        return new ResponseEntity<>(HttpStatus.OK);
    }

    @DeleteMapping(value = "delete/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Void> deleteById(@PathVariable int id){
        todoService.deleteById(id);
        return new ResponseEntity<>(HttpStatus.OK);
    }
}
