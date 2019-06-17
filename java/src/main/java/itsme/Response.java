package itsme;

import com.sun.jna.Structure;
import java.util.Arrays;
import java.util.List;

public class Response extends Structure implements Structure.ByValue{
    public String data;
    public String error;

    protected List getFieldOrder() {
        return Arrays.asList(new String[]{"data", "error"});
    }
}
