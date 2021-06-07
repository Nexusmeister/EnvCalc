package de.crystalcase.envcalc.data;

import lombok.Builder;
import lombok.Data;

import java.util.List;

@Data
@Builder
public class RootEntityData {

    private String name;
    private List<ExchangeData> exchanges;

}
