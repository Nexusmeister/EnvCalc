package de.crystalcase.envcalc.entities;

import lombok.Getter;
import lombok.Setter;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

@Getter
@Setter
@Document(indexName = "probas")
public class Category {

    @Id
    private String id;
    private String name;

}
