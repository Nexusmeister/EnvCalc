package de.crystalcase.envcalc.repositories;

import de.crystalcase.envcalc.data.Exchanges;
import de.crystalcase.envcalc.repositories.exchanges.ExchangesCustomRepository;
import org.springframework.data.elasticsearch.repository.ElasticsearchRepository;

public interface ExchangesRepository extends ElasticsearchRepository<Exchanges, String>, ExchangesCustomRepository {

}
