package de.crystalcase.envcalc.repositories.exchanges;

import de.crystalcase.envcalc.entities.Exchanges;
import org.springframework.data.elasticsearch.core.SearchHits;


public interface ExchangesCustomRepository {
    SearchHits<Exchanges> findByNameWithUniqueExchanges();
    SearchHits<Exchanges> findByNameWithUniqueExchanges(String name);
}
