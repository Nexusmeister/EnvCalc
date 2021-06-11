package de.crystalcase.envcalc.repositories;

import de.crystalcase.envcalc.entities.Exchange;
import org.springframework.data.elasticsearch.repository.ElasticsearchRepository;
import org.springframework.data.repository.Repository;

public interface ExchangeRepository extends ElasticsearchRepository<Exchange, String> {
}
