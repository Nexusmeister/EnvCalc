package de.crystalcase.envcalc.repositories.exchanges;

import de.crystalcase.envcalc.data.Exchanges;
import org.springframework.data.elasticsearch.core.SearchHits;


public interface ExchangesCustomRepository {
    SearchHits<Exchanges> findByNameWithUniqueExchanges(String name);
}
