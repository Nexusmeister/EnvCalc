package de.crystalcase.envcalc.repositories;

import de.crystalcase.envcalc.entities.RootEntity;
import de.crystalcase.envcalc.enums.RootEntityTypes;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.data.repository.Repository;

public interface RootEntityRepository  extends Repository<RootEntity, String>{

    SearchHits<RootEntity> findAllByType(RootEntityTypes type);
    SearchHits<RootEntity> findAllById(String id);


}
