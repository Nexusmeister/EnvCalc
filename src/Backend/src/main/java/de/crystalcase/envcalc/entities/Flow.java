package de.crystalcase.envcalc.entities;

import lombok.Getter;
import lombok.Setter;
import nonapi.io.github.classgraph.json.Id;
import org.springframework.data.elasticsearch.annotations.Document;
import org.springframework.data.elasticsearch.annotations.Field;

@Getter
@Setter
@Document(indexName = "probas")
public class Flow {
    @Id
    String id;
    String name;
}
