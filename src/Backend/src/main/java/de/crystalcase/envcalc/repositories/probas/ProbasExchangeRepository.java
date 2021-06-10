package de.crystalcase.envcalc.repositories.probas;

import de.crystalcase.envcalc.entities.probas.ProbasExchange;
import de.crystalcase.envcalc.repositories.probas.exchanges.ProbasExchangeCustomRepository;
import org.springframework.data.elasticsearch.repository.ElasticsearchRepository;

public interface ProbasExchangeRepository extends ElasticsearchRepository<ProbasExchange, String>, ProbasExchangeCustomRepository {

}
