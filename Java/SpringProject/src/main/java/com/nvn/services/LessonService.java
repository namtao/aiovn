package com.nvn.services;

import java.util.List;
import java.util.Optional;

import com.nvn.entities.LessonId;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.nvn.entities.Lesson;
//import com.nvn.model.Lesson;
import com.nvn.repository.ILessonRepository;

@Service
public class LessonService implements IServices<Lesson, LessonId> {

	@Autowired
    ILessonRepository lessonRepository;
	
	public List<Lesson> getAll(String name) {
		return lessonRepository.getAll(name);
	}

	public Lesson findByName(String name, String url) {
		return lessonRepository.findByName(name, url);
	}

	public Lesson findById(int subjectId, String url) {
		return lessonRepository.findById(subjectId, url);
	}

	public void insert(Lesson lesson) {
		lessonRepository.save(lesson);
	}

	public void update(Lesson lesson) {
		lessonRepository.save(lesson);
	}

	@Override
	public void delete(Lesson lesson) {

	}

	@Override
	public void deleteById(LessonId id) {

	}

	public void delete(int subjectId, String url) {
		lessonRepository.delete(subjectId, url);
	}

	public List<Lesson> getAll() {
		return lessonRepository.findAll();
	}

	@Override
	public Optional<Lesson> findById(Integer id) {
		return null;
	}

}
