package de.crystalcase.envcalc.entities;

import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

@Document(indexName = "probas")
public class RootEntity {

    @Id
    private String id;
    private String name;
    private Category category;
    private Exchanges exchanges;

}