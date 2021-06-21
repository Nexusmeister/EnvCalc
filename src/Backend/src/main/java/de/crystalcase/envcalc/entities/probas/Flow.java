package de.crystalcase.envcalc.entities.probas;

import lombok.Getter;
import lombok.Setter;
import nonapi.io.github.classgraph.json.Id;
import org.springframework.data.elasticsearch.annotations.Document;

@Getter
@Setter
@Document(indexName = "probas")
public class Flow {
    @Id
    String id;
    String name;
}
