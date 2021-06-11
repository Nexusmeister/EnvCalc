package de.crystalcase.envcalc.entities;


import com.fasterxml.jackson.annotation.JsonFormat;
import lombok.Builder;
import lombok.Getter;
import lombok.Setter;
import org.joda.time.DateTime;
import org.joda.time.Instant;
import org.springframework.data.annotation.CreatedDate;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.DateFormat;
import org.springframework.data.elasticsearch.annotations.Document;
import org.springframework.data.elasticsearch.annotations.Field;
import org.springframework.data.elasticsearch.annotations.FieldType;

import java.util.List;

@Getter
@Setter
@Builder
@Document(indexName = "envcalc")
public class Product {
    @Id
    private String id;
    private String name;
    private Integer version;
    private List<Process> processes;
    private Boolean deprecated;
    @Field(type = FieldType.Date)
    private Long created;


}
