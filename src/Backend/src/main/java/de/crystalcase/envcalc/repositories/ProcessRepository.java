package de.crystalcase.envcalc.repositories;

import de.crystalcase.envcalc.entities.Process;
import org.springframework.data.elasticsearch.repository.ElasticsearchRepository;
import org.springframework.data.repository.Repository;

import java.util.List;

public interface ProcessRepository extends ElasticsearchRepository<Process, String> {
    List<Process> findAll();

}
