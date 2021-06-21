package de.crystalcase.envcalc.repositories.probas;

import de.crystalcase.envcalc.entities.probas.RootEntity;
import de.crystalcase.envcalc.enums.RootEntityTypes;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.data.elasticsearch.repository.ElasticsearchRepository;

public interface RootEntityRepository  extends ElasticsearchRepository<RootEntity, String> {

    SearchHits<RootEntity> findAllByType(RootEntityTypes type);
    SearchHits<RootEntity> findAllById(String id);


}
