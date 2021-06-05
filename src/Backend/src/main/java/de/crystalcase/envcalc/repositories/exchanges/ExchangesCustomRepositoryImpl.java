package de.crystalcase.envcalc.repositories.exchanges;

import de.crystalcase.envcalc.entities.Exchanges;
import org.elasticsearch.search.aggregations.AggregationBuilders;
import org.springframework.data.elasticsearch.core.ElasticsearchOperations;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.data.elasticsearch.core.query.NativeSearchQuery;
import org.springframework.data.elasticsearch.core.query.NativeSearchQueryBuilder;

public class ExchangesCustomRepositoryImpl implements ExchangesCustomRepository {
    private final ElasticsearchOperations operations;

    public ExchangesCustomRepositoryImpl(ElasticsearchOperations operations){
        this.operations = operations;
    }

    @Override
    public SearchHits<Exchanges> findByNameWithUniqueExchanges() {
        return findByNameWithUniqueExchanges("");
    }

    @Override
    public SearchHits<Exchanges> findByNameWithUniqueExchanges(String name){
        NativeSearchQuery query = new NativeSearchQueryBuilder()
                .addAggregation(AggregationBuilders.terms("uniq_exchanges")
                        .field("exchanges.flow.name.keyword").size(3000))
                .build();
        query.setMaxResults(0);
        SearchHits<Exchanges> searchHits = operations.search(query, Exchanges.class);
        return searchHits;
    }
}
