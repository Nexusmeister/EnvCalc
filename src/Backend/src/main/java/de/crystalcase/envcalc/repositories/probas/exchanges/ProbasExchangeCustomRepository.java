package de.crystalcase.envcalc.repositories.probas.exchanges;

import de.crystalcase.envcalc.entities.probas.ProbasExchange;
import org.springframework.data.elasticsearch.core.SearchHits;


public interface ProbasExchangeCustomRepository {
    SearchHits<ProbasExchange> findUniqueExchanges();
    SearchHits<ProbasExchange> findUniqueUnits();
}
