package de.crystalcase.envcalc.repositories;

import de.crystalcase.envcalc.data.Category;
import org.springframework.data.elasticsearch.core.SearchHit;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.data.elasticsearch.core.SearchPage;
import org.springframework.data.repository.Repository;

import java.util.List;

public interface CategoryRepository extends Repository<Category, String> {

    List<Category> findAll();
}
