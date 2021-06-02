package com.nvn.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import com.nvn.entities.Lesson;

@Repository
public interface ILessonRepository extends JpaRepository<Lesson, Integer> {

	@Query("select les from Lesson les where les.subject.subjectName= :name")
	public List<Lesson> getAll(@Param("name") String name);

	@Query("select les FROM Lesson les WHERE url = :url and les.subject.subjectId=(select sub.subjectId from Subject sub where sub.subjectName= :name)")
	public Lesson findByName(@Param("name") String name, @Param("url") String url);

	@Query("select les from Lesson les where les.id.subjectId= :subjectId and les.id.url= :url")
	public Lesson findById(@Param("subjectId")int subjectId,@Param("url") String url);

	@Transactional
	@Modifying
	@Query("delete Lesson les where les.id.subjectId= :subjectId and les.id.url= :url")
	public void delete(@Param("subjectId")int subjectId,@Param("url") String url);
	
}