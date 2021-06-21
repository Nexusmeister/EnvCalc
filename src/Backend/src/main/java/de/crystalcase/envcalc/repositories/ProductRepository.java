package de.crystalcase.envcalc.repositories;

import de.crystalcase.envcalc.entities.Product;
import org.springframework.data.elasticsearch.repository.ElasticsearchRepository;


import java.util.List;
import java.util.Optional;

public interface ProductRepository extends ElasticsearchRepository<Product, String> {

    List<Product> findAll();
    Optional<Product> findById(Long id);
    Optional<Product> findByName(String name);
}



