package com.nvn.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.nvn.entities.Category;
import com.nvn.repository.ICategoryRepository;


@Service
public class CategoryService implements IServices<Category, Integer>{

	@Autowired
    ICategoryRepository categoryDAO;

	public List<Category> getAll() {
		return categoryDAO.findAll();
	}

	@Override
	public Optional<Category> findById(Integer id) {
		return Optional.empty();
	}

	public List<Category> getAll(String tableName) {
		return null;
	}

	public Category findById(int subjectId, String url) {
		return null;
	}

	public Category findByName(String subname, String name) {
		return null;
	}

	public void insert(Category k) {
		categoryDAO.save(k);
	}

	@Override
	public void update(Category category) {

	}

	@Override
	public void delete(Category category) {

	}

	@Override
	public void deleteById(Integer id) {

	}

	public void update(Category k, int subjectId, String url) {

	}

	public void delete(String name, String url) {

	}

}
