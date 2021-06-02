package com.nvn.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.nvn.entities.Subject;
import com.nvn.repository.ISubjectRepository;

@Service
public class SubjectService implements IServices<Subject, Integer>{

	@Autowired
    ISubjectRepository subjectRepository;
	
	public List<Subject> getAll() {
		return subjectRepository.findAll();
	}

	@Override
	public Optional findById(Integer id) {
		return Optional.empty();
	}

	@Override
	public void insert(Subject subject) {

	}

	@Override
	public void update(Subject subject) {

	}

	@Override
	public void delete(Subject subject) {

	}

	@Override
	public void deleteById(Integer id) {

	}
}
