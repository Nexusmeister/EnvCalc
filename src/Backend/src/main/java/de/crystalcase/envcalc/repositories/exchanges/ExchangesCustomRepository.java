package de.crystalcase.envcalc.repositories.exchanges;

import de.crystalcase.envcalc.entities.Exchange;
import org.springframework.data.elasticsearch.core.SearchHits;


public interface ExchangesCustomRepository {
    SearchHits<Exchange> findUniqueExchanges();
    SearchHits<Exchange> findUniqueUnits();
}
