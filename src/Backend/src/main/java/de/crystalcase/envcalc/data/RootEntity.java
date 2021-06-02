package de.crystalcase.envcalc.data;

import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;
import org.springframework.data.elasticsearch.annotations.Field;

@Document(indexName = "probas")
public class RootEntity {

    @Id
    private String id;

    private Category category;

}
