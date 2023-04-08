# Enum Flags in unity, two ways<br>
<br>

## Enum Flags Attribute
This attribute is used on an enum you want to act as a flag mask, while the base enum behaves standardly.<br>
Use this if having a flag mask is an exception.<br>
Just use the attribute `[EnumFlags]` above your field.
<br>
## System Enum Flag
This uses the System.Flags attribute on your base enum to transform it into a flag mask.<br><br>
Another attribute, SingleEnumFlagSelectAttribute exists on an enum you want to only allow one flag to be selected at a time.
Use this if having an unique flag value is an exception.<br>
You will have to use `[SingleEnumFlagSelect(EnumType = typeof(<your enum here>))]` above your one-value-only field for it to work.

### Bonus material
Along with each method a BitMaskOperation helper is provided for easier handling of bit operations.
System Enum Flag also has an extension method that replaces Enum.IsDefined since at the time this native method doesn't work well with flags and always returns false. Thinking if this should be changed to a non-extension method to conform with Microsoft design guidelines.
