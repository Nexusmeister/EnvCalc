package de.crystalcase.envcalc.repositories;

import de.crystalcase.envcalc.entities.Exchange;
import org.springframework.data.elasticsearch.repository.ElasticsearchRepository;

public interface ExchangeRepository extends ElasticsearchRepository<Exchange, String> {
}
