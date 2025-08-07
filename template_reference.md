# Template Reference - XML Template Syntax

This guide provides comprehensive documentation for the JayPDFLibs XML template system, with extensive Thai language examples.

## 📚 Table of Contents

1. [Template Structure](#-template-structure)
2. [Basic Elements](#-basic-elements)
3. [Text Elements](#-text-elements)
4. [Layout Elements](#-layout-elements)
5. [Table Elements](#-table-elements)
6. [Variables and Expressions](#-variables-and-expressions)
7. [Control Structures](#-control-structures)
8. [Functions and Filters](#-functions-and-filters)
9. [Thai Language Features](#-thai-language-features)
10. [Advanced Features](#-advanced-features)

## 🏗️ Template Structure

### Basic Template Structure
```xml
<?xml version="1.0" encoding="utf-8"?>
<pdf-template version="1.0" xmlns="http://jaypdflibrary.com/template">
  <metadata>
    <title>เอกสารตัวอย่าง</title>
    <author>ผู้สร้าง</author>
    <subject>หัวข้อเอกสาร</subject>
    <keywords>PDF, Thai, Template</keywords>
  </metadata>
  
  <fonts>
    <font name="sarabun" file="Sarabun-Regular.ttf" embed="true"/>
    <font name="sarabun-bold" file="Sarabun-Bold.ttf" embed="true"/>
  </fonts>
  
  <page size="A4" orientation="portrait" margins="20,30,20,40">
    <!-- Page content here -->
  </page>
</pdf-template>
```

### Multiple Pages
```xml
<pdf-template>
  <!-- First page: Cover -->
  <page size="A4" margins="0,0,0,0">
    <text x="center" y="400" font="sarabun-bold" size="24" align="center">
      ปกหน้า
    </text>
  </page>
  
  <!-- Subsequent pages: Content -->
  <page size="A4" margins="20,20,20,20">
    <header>
      <text x="100" y="750" font="sarabun" size="10">หัวกระดาษ</text>
    </header>
    
    <body>
      <text x="100" y="700" font="sarabun" size="12">เนื้อหาหลัก</text>
    </body>
    
    <footer>
      <text x="center" y="40" font="sarabun" size="8">ท้ายกระดาษ</text>
    </footer>
  </page>
</pdf-template>
```

## 🔤 Basic Elements

### Page Element
```xml
<page 
  size="A4|Letter|A3|Legal|Custom"
  orientation="portrait|landscape" 
  margins="left,top,right,bottom"
  background-color="#ffffff">
  
  <!-- Content -->
  
</page>

<!-- Examples -->
<page size="A4" orientation="portrait" margins="20,20,20,20"/>
<page size="Letter" orientation="landscape" margins="25,25,25,25"/>
<page size="Custom" width="300" height="400" margins="10,10,10,10"/>
```

### Coordinate System
```xml
<!-- Absolute positioning -->
<text x="100" y="700">ตำแหน่งแน่นอน</text>

<!-- Relative positioning -->
<text x="center" y="700">กึ่งกลางหน้า</text>
<text x="right" y="700" margin-right="20">ขวาสุด</text>

<!-- Percentage positioning -->
<text x="50%" y="80%">ตำแหน่งเปอร์เซ็นต์</text>
```

## 📝 Text Elements

### Basic Text
```xml
<text 
  x="100" 
  y="700" 
  font="sarabun" 
  size="12" 
  color="#000000"
  align="left|center|right|justify"
  bold="true|false"
  italic="true|false"
  underline="true|false">
  
  ข้อความภาษาไทย
</text>
```

### Text Formatting Examples
```xml
<!-- Basic Thai text -->
<text x="100" y="700" font="sarabun" size="14">
  สวัสดีครับ ยินดีต้อนรับ
</text>

<!-- Bold Thai text -->
<text x="100" y="680" font="sarabun-bold" size="16" bold="true">
  หัวข้อสำคัญ
</text>

<!-- Colored text -->
<text x="100" y="660" font="sarabun" size="12" color="#ff0000">
  ข้อความสีแดง
</text>

<!-- Aligned text -->
<text x="center" y="640" font="sarabun" size="14" align="center">
  ข้อความกึ่งกลาง
</text>

<!-- Multi-style text (using spans) -->
<text x="100" y="620" font="sarabun" size="12">
  ข้อความปกติ <span bold="true">ข้อความหนา</span> และ <span color="#blue">สีน้ำเงิน</span>
</text>
```

### Text Block (Multi-line)
```xml
<text-block 
  x="100" 
  y="600" 
  width="400" 
  height="100"
  font="sarabun" 
  size="12"
  line-height="1.5"
  align="justify"
  vertical-align="top">
  
  นี่คือข้อความหลายบรรทัดที่จะถูกจัดรูปแบบอัตโนมัติ
  ตามความกว้างที่กำหนดไว้ สามารถใช้งานได้ดีกับภาษาไทย
  และจะจัดวรรณยุกต์ให้ถูกต้องตามหลักภาษาไทย
  
  ย่อหน้าใหม่จะเว้นบรรทัด
  
</text-block>
```

### Rich Text
```xml
<rich-text x="100" y="500" width="400">
  <p font="sarabun" size="14" align="center">
    <b>หัวข้อเอกสาร</b>
  </p>
  
  <p font="sarabun" size="12" line-height="1.6">
    เนื้อหาย่อหน้าแรก มีการใช้ <b>ตัวหนา</b> และ <i>ตัวเอียง</i> 
    รวมถึง <u>ขีดเส้นใต้</u> และ <span color="#red">สีต่างๆ</span>
  </p>
  
  <ul>
    <li>รายการที่ 1</li>
    <li>รายการที่ 2</li>
    <li>รายการที่ 3</li>
  </ul>
</rich-text>
```

## 🎨 Layout Elements

### Line
```xml
<line 
  x1="100" y1="700" 
  x2="400" y2="700" 
  color="#000000" 
  width="1"
  style="solid|dashed|dotted"/>

<!-- Examples -->
<line x1="100" y1="700" x2="500" y2="700" color="#cccccc" width="0.5"/>
<line x1="100" y1="680" x2="500" y2="680" color="#000000" width="2" style="dashed"/>
```

### Rectangle
```xml
<rectangle 
  x="100" y="600" 
  width="200" height="100"
  fill-color="#f0f0f0"
  border-color="#000000"
  border-width="1"
  border-style="solid"
  corner-radius="5"/>

<!-- Example with Thai text inside -->
<rectangle x="100" y="600" width="300" height="60" fill-color="#e6f3ff" border-color="#0066cc">
  <text x="center" y="center" font="sarabun" size="14" align="center">
    กรอบข้อความ
  </text>
</rectangle>
```

### Circle/Ellipse
```xml
<circle 
  x="200" y="500" 
  radius="50"
  fill-color="#ffff00"
  border-color="#ff0000"
  border-width="2"/>

<ellipse 
  x="200" y="400" 
  width="100" height="60"
  fill-color="#00ff00"
  border-color="#008000"/>
```

### Image
```xml
<image 
  src="logo.png"
  x="100" y="700" 
  width="100" height="50"
  align="left|center|right"
  valign="top|middle|bottom"
  fit="contain|cover|fill|none"/>

<!-- Examples -->
<image src="company-logo.png" x="100" y="750" width="80" height="40"/>
<image src="signature.jpg" x="right" y="100" width="150" height="75" margin-right="50"/>
```

## 📊 Table Elements

### Basic Table
```xml
<table x="100" y="600" width="400" border="1" border-color="#000000">
  <headers font="sarabun-bold" size="12" background-color="#f0f0f0" height="30">
    <column width="200" align="left">รายการ</column>
    <column width="100" align="center">จำนวน</column>
    <column width="100" align="right">ราคา</column>
  </headers>
  
  <rows font="sarabun" size="10" height="25">
    <row>
      <column>สินค้า A</column>
      <column>2</column>
      <column>฿200.00</column>
    </row>
    <row background-color="#f9f9f9">
      <column>สินค้า B</column>
      <column>1</column>
      <column>฿150.00</column>
    </row>
  </rows>
  
  <footer font="sarabun-bold" size="11" background-color="#e0e0e0" height="35">
    <column colspan="2" align="right">รวมทั้งสิ้น:</column>
    <column align="right">฿350.00</column>
  </footer>
</table>
```

### Dynamic Table with Data Source
```xml
<table x="100" y="500" width="450" border="1">
  <headers font="sarabun-bold" size="12" background-color="#4a90e2" color="#ffffff">
    <column width="150">ชื่อพนักงาน</column>
    <column width="100">ตำแหน่ง</column>
    <column width="100">แผนก</column>
    <column width="100">เงินเดือน</column>
  </headers>
  
  <rows data-source="employees" font="sarabun" size="10">
    <row>
      <column>{{name}}</column>
      <column align="center">{{position}}</column>
      <column align="center">{{department}}</column>
      <column align="right">฿{{salary | number:0}}</column>
    </row>
  </rows>
  
  <footer font="sarabun-bold" size="11">
    <column colspan="3" align="right">เงินเดือนรวม:</column>
    <column align="right">฿{{employees | sum:'salary' | number:0}}</column>
  </footer>
</table>
```

### Advanced Table Features
```xml
<!-- Table with alternating row colors -->
<table x="100" y="400" width="400">
  <rows data-source="items" font="sarabun" size="10" alternate-colors="true" 
        even-color="#ffffff" odd-color="#f8f9fa">
    <row>
      <column>{{name}}</column>
      <column>{{value}}</column>
    </row>
  </rows>
</table>

<!-- Table with conditional formatting -->
<table x="100" y="350" width="400">
  <rows data-source="students" font="sarabun" size="10">
    <row background-color="{{#if (gt score 80)}}#d4edda{{else if (gt score 60)}}#fff3cd{{else}}#f8d7da{{/if}}">
      <column>{{name}}</column>
      <column>{{score}}</column>
      <column>{{#if (gt score 80)}}ดีเยี่ยม{{else if (gt score 60)}}พอใช้{{else}}ต้องปรับปรุง{{/if}}</column>
    </row>
  </rows>
</table>
```

## 🔧 Variables and Expressions

### Basic Variable Syntax
```xml
<!-- Simple variable -->
{{variable_name}}

<!-- Object property -->
{{customer.name}}
{{customer.address.city}}

<!-- Array access -->
{{items[0].name}}
{{products[index].price}}

<!-- With default values -->
{{customer.email | default:'ไม่ระบุ'}}
```

### Thai Language Variables
```xml
<!-- Thai text variables -->
<text x="100" y="700" font="sarabun" size="14">
  ชื่อลูกค้า: {{customer.thai_name}}
</text>

<!-- Thai date formatting -->
<text x="100" y="680" font="sarabun" size="12">
  วันที่: {{invoice.date | thai_date}}
</text>

<!-- Thai number formatting -->
<text x="100" y="660" font="sarabun" size="12">
  จำนวนเงิน: {{amount | thai_currency}} บาท
</text>

<!-- Thai ordinal numbers -->
<text x="100" y="640" font="sarabun" size="12">
  ลำดับที่ {{order | thai_ordinal}}
</text>
```

### Expression Evaluation
```xml
<!-- Mathematical expressions -->
{{price * quantity}}
{{(subtotal + tax) - discount}}
{{items | sum:'price' | multiply:1.07}}

<!-- String operations -->
{{first_name + ' ' + last_name}}
{{address | upper}}
{{description | truncate:50}}

<!-- Comparisons -->
{{#if (gt total 1000)}}ลูกค้า VIP{{else}}ลูกค้าทั่วไป{{/if}}
{{#if (eq status 'active')}}ใช้งานอยู่{{else}}ไม่ได้ใช้งาน{{/if}}
```

## 🔄 Control Structures

### Conditional Rendering
```xml
<!-- If statement -->
{{#if customer.is_vip}}
  <text x="100" y="700" font="sarabun-bold" size="14" color="#gold">
    ลูกค้าพิเศษ VIP
  </text>
{{/if}}

<!-- If-else statement -->
{{#if (gt order.total 5000)}}
  <text x="100" y="680" font="sarabun" size="12" color="#green">
    ได้รับส่วนลด 10%
  </text>
{{else}}
  <text x="100" y="680" font="sarabun" size="12">
    ยอดซื้อไม่ถึงเกณฑ์ส่วนลด
  </text>
{{/if}}

<!-- Multiple conditions -->
{{#if (eq customer.level 'gold')}}
  <rectangle x="90" y="695" width="20" height="20" fill-color="#ffd700"/>
{{else if (eq customer.level 'silver')}}
  <rectangle x="90" y="695" width="20" height="20" fill-color="#c0c0c0"/>
{{else}}
  <rectangle x="90" y="695" width="20" height="20" fill-color="#cd7f32"/>
{{/if}}
```

### Loops and Iteration
```xml
<!-- Basic loop -->
{{#each items}}
  <text x="100" y="{{@y_position}}" font="sarabun" size="12">
    รายการที่ {{@index_1}}: {{name}} - ฿{{price}}
  </text>
{{/each}}

<!-- Loop with custom positioning -->
{{#each products}}
  <text x="100" y="{{subtract 700 (multiply @index 20)}}" font="sarabun" size="10">
    {{thai_name}} ({{code}})
  </text>
{{/each}}

<!-- Loop with conditions -->
{{#each orders}}
  {{#if (eq status 'completed')}}
    <text x="100" y="{{@y_pos}}" font="sarabun" size="10" color="#green">
      ✓ คำสั่งซื้อ #{{id}} - สำเร็จ
    </text>
  {{else if (eq status 'pending')}}
    <text x="100" y="{{@y_pos}}" font="sarabun" size="10" color="#orange">
      ⏳ คำสั่งซื้อ #{{id}} - รอดำเนินการ
    </text>
  {{/if}}
{{/each}}

<!-- Nested loops -->
{{#each categories}}
  <text x="100" y="{{@y_pos}}" font="sarabun-bold" size="14">
    หมวดหมู่: {{thai_name}}
  </text>
  {{#each products}}
    <text x="120" y="{{@parent_y_pos}}" font="sarabun" size="10">
      - {{name}}: ฿{{price}}
    </text>
  {{/each}}
{{/each}}
```

### Loop Variables
```xml
<!-- Available loop variables -->
{{#each items}}
  {{@index}}       <!-- 0-based index -->
  {{@index_1}}     <!-- 1-based index -->
  {{@first}}       <!-- true for first item -->
  {{@last}}        <!-- true for last item -->
  {{@odd}}         <!-- true for odd index items -->
  {{@even}}        <!-- true for even index items -->
  {{@length}}      <!-- total number of items -->
  {{@y_pos}}       <!-- auto-calculated Y position -->
{{/each}}
```

## 🧮 Functions and Filters

### Text Functions
```xml
<!-- String manipulation -->
{{text | upper}}                    <!-- UPPERCASE -->
{{text | lower}}                    <!-- lowercase -->
{{text | title}}                    <!-- Title Case -->
{{text | truncate:50}}              <!-- Truncate to 50 characters -->
{{text | truncate:50:'...'}}        <!-- Truncate with custom suffix -->
{{text | replace:'old':'new'}}      <!-- Replace text -->
{{text | trim}}                     <!-- Remove whitespace -->
{{text | length}}                   <!-- Get string length -->

<!-- Thai-specific text functions -->
{{thai_text | thai_sort}}           <!-- Sort by Thai alphabetical order -->
{{thai_text | thai_normalize}}      <!-- Normalize Thai characters -->
{{thai_text | remove_tone_marks}}   <!-- Remove tone marks for sorting -->
```

### Number Functions
```xml
<!-- Number formatting -->
{{number | format:'n2'}}            <!-- 1,234.56 -->
{{number | format:'c'}}             <!-- Currency format -->
{{number | format:'p'}}             <!-- Percentage format -->
{{number | round:2}}                <!-- Round to 2 decimal places -->
{{number | ceil}}                   <!-- Round up -->
{{number | floor}}                  <!-- Round down -->
{{number | abs}}                    <!-- Absolute value -->

<!-- Thai number formatting -->
{{number | thai_number}}            <!-- Convert to Thai numerals: ๑,๒๓๔.๕๖ -->
{{amount | thai_currency}}          <!-- Format as Thai currency -->
{{number | thai_text}}              <!-- Convert to Thai text: หนึ่งพันสองร้อย -->
{{number | thai_ordinal}}           <!-- Thai ordinal: ที่หนึ่ง, ที่สอง -->
```

### Date Functions
```xml
<!-- Date formatting -->
{{date | format:'yyyy-MM-dd'}}      <!-- 2025-01-15 -->
{{date | format:'dd/MM/yyyy'}}      <!-- 15/01/2025 -->
{{date | format:'MMMM yyyy'}}       <!-- January 2025 -->
{{date | format:'dddd, dd MMMM yyyy'}} <!-- Tuesday, 15 January 2025 -->

<!-- Thai date formatting -->
{{date | thai_date}}                <!-- ๑๕ มกราคม ๒๕๖๘ -->
{{date | thai_date_long}}           <!-- วันอังคารที่ ๑๕ มกราคม พ.ศ. ๒๕๖๘ -->
{{date | thai_month}}               <!-- มกราคม -->
{{date | thai_year}}                <!-- ๒๕๖๘ -->
{{date | buddhist_year}}            <!-- พ.ศ. ๒๕๖๘ -->

<!-- Date calculations -->
{{date | add_days:30}}              <!-- Add 30 days -->
{{date | add_months:1}}             <!-- Add 1 month -->
{{date | subtract_days:7}}          <!-- Subtract 7 days -->
{{date | age}}                      <!-- Calculate age -->
```

### Array Functions
```xml
<!-- Array operations -->
{{items | count}}                   <!-- Count items -->
{{items | first}}                   <!-- First item -->
{{items | last}}                    <!-- Last item -->
{{items | take:5}}                  <!-- Take first 5 items -->
{{items | skip:3}}                  <!-- Skip first 3 items -->
{{items | reverse}}                 <!-- Reverse array -->
{{items | sort:'name'}}             <!-- Sort by property -->
{{items | sort_desc:'price'}}       <!-- Sort descending -->

<!-- Aggregation functions -->
{{prices | sum}}                    <!-- Sum all values -->
{{prices | average}}                <!-- Average value -->
{{prices | min}}                    <!-- Minimum value -->
{{prices | max}}                    <!-- Maximum value -->
{{items | sum:'price'}}             <!-- Sum by property -->
{{items | average:'rating'}}        <!-- Average by property -->

<!-- Filtering -->
{{items | where:'active':true}}     <!-- Filter by property -->
{{items | where:'price':'gt':100}}  <!-- Filter by condition -->
```

### Conditional Functions
```xml
<!-- Comparison operators -->
{{#if (eq value1 value2)}}Equal{{/if}}
{{#if (ne value1 value2)}}Not Equal{{/if}}
{{#if (gt value1 value2)}}Greater Than{{/if}}
{{#if (gte value1 value2)}}Greater Than or Equal{{/if}}
{{#if (lt value1 value2)}}Less Than{{/if}}
{{#if (lte value1 value2)}}Less Than or Equal{{/if}}

<!-- Logical operators -->
{{#if (and condition1 condition2)}}Both True{{/if}}
{{#if (or condition1 condition2)}}At Least One True{{/if}}
{{#if (not condition)}}Not True{{/if}}

<!-- Thai-specific conditions -->
{{#if (thai_is_vowel character)}}สระ{{else}}พยัญชนะ{{/if}}
{{#if (thai_is_tone_mark character)}}วรรณยุกต์{{/if}}
```

## 🌏 Thai Language Features

### Thai Font Handling
```xml
<fonts>
  <!-- Define Thai fonts with proper fallbacks -->
  <font name="sarabun" file="Sarabun-Regular.ttf" 
        fallback="noto-sans-thai,arial-unicode-ms" embed="true"/>
  <font name="sarabun-bold" file="Sarabun-Bold.ttf" 
        fallback="noto-sans-thai,arial-unicode-ms" embed="true"/>
  
  <!-- Font family definitions -->
  <font-family name="thai-serif">
    <font weight="normal" file="TH Sarabun New.ttf"/>
    <font weight="bold" file="TH Sarabun New Bold.ttf"/>
    <font weight="light" file="TH Sarabun New Light.ttf"/>
  </font-family>
</fonts>

<!-- Using Thai fonts in content -->
<text font="sarabun" size="14">ข้อความภาษาไทย</text>
<text font-family="thai-serif" weight="bold" size="16">หัวข้อสำคัญ</text>
```

### Thai Text Layout
```xml
<!-- Thai text with proper line breaking -->
<text-block x="100" y="600" width="400" height="100" 
            font="sarabun" size="12" 
            text-direction="ltr"
            word-break="thai-break"
            line-break="strict">
  
  ข้อความภาษาไทยที่ยาวมากและต้องการการตัดคำที่ถูกต้องตามหลักภาษาไทย
  โดยระบบจะตัดคำอย่างเหมาะสมไม่ให้เกิดการตัดผิดหลักไวยากรณ์
  
</text-block>

<!-- Mixed Thai-English text -->
<text font="sarabun" size="12">
  บริษัท ABC Company Limited จำกัด
</text>

<!-- Thai numerals -->
<text font="sarabun" size="12">
  ราคา: ฿๑,๒๓๔.๕๖ (หนึ่งพันสองร้อยสามสิบสี่บาทห้าสิบหกสตางค์)
</text>
```

### Thai-specific Templates
```xml
<!-- Thai invoice template -->
<pdf-template>
  <page size="A4" margins="20,20,20,20">
    <!-- Thai header -->
    <text x="center" y="750" font="sarabun-bold" size="18" align="center">
      ใบแจ้งหนี้ / INVOICE
    </text>
    
    <!-- Thai company information -->
    <text-block x="100" y="720" width="200" font="sarabun" size="10">
      {{company.thai_name}}
      {{company.english_name}}
      {{company.thai_address}}
      เลขประจำตัวผู้เสียภาษี: {{company.tax_id}}
    </text-block>
    
    <!-- Thai customer information -->
    <text-block x="320" y="720" width="200" font="sarabun" size="10">
      ลูกค้า: {{customer.thai_name}}
      {{customer.english_name}}
      {{customer.thai_address}}
      เลขประจำตัวผู้เสียภาษี: {{customer.tax_id}}
    </text-block>
    
    <!-- Thai table -->
    <table x="100" y="600" width="400" border="1">
      <headers font="sarabun-bold" size="12" background-color="#e6f3ff">
        <column width="200">รายการสินค้า/บริการ</column>
        <column width="60">จำนวน</column>
        <column width="70">ราคาต่อหน่วย</column>
        <column width="70">จำนวนเงิน</column>
      </headers>
      
      <rows data-source="items" font="sarabun" size="10">
        <row>
          <column>{{thai_description}}</column>
          <column align="center">{{quantity | thai_number}}</column>
          <column align="right">{{unit_price | thai_currency}}</column>
          <column align="right">{{total_price | thai_currency}}</column>
        </row>
      </rows>
      
      <footer font="sarabun-bold" size="11">
        <column colspan="3" align="right">รวมเงิน:</column>
        <column align="right">{{subtotal | thai_currency}}</column>
      </footer>
      <footer font="sarabun-bold" size="11">
        <column colspan="3" align="right">ภาษีมูลค่าเพิ่ม 7%:</column>
        <column align="right">{{vat | thai_currency}}</column>
      </footer>
      <footer font="sarabun-bold" size="12" background-color="#e6f3ff">
        <column colspan="3" align="right">รวมทั้งสิ้น:</column>
        <column align="right">{{total | thai_currency}}</column>
      </footer>
    </table>
    
    <!-- Thai amount in words -->
    <text x="100" y="400" font="sarabun" size="10">
      ({{total | thai_text_amount}})
    </text>
  </page>
</pdf-template>
```

### Thai Cultural Elements
```xml
<!-- Thai calendar and festivals -->
<text font="sarabun" size="12">
  วันที่: {{date | thai_date}} ({{date | thai_day_name}})
  {{#if (thai_is_holiday date)}}
    <span color="#red">วันหยุดนักขัตฤกษ์</span>
  {{/if}}
</text>

<!-- Thai address formatting -->
<text-block font="sarabun" size="10" line-height="1.4">
  {{address.number}} {{address.moo}} {{address.soi}} {{address.road}}
  {{address.subdistrict}} {{address.district}}
  {{address.province}} {{address.postal_code}}
</text-block>

<!-- Thai business terms -->
<text font="sarabun" size="10">
  {{#eq payment_method 'cash'}}เงินสด{{/eq}}
  {{#eq payment_method 'transfer'}}โอนเงิน{{/eq}}
  {{#eq payment_method 'cheque'}}เช็ค{{/eq}}
  {{#eq payment_method 'credit'}}เครดิต{{/eq}}
</text>
```

## 🚀 Advanced Features

### Dynamic Content Generation
```xml
<!-- QR Code generation -->
<qr-code x="400" y="100" size="80" data="{{invoice.url}}" 
         error-correction="M" border="2"/>

<!-- Barcode generation -->
<barcode type="Code128" x="100" y="50" width="200" height="30" 
         data="{{product.sku}}" show-text="true"/>

<!-- Chart generation -->
<chart type="pie" x="100" y="400" width="300" height="200"
       data-source="sales_data" 
       title="ยอดขายตามหมวดหมู่">
  <series name="category" value="amount" color="auto"/>
</chart>
```

### Page Management
```xml
<!-- Page breaks -->
<page-break condition="{{@row_count > 25}}"/>
<page-break force="true"/>

<!-- Page numbering -->
<text x="center" y="40" font="sarabun" size="8">
  หน้า {{@page_number}} จาก {{@total_pages}}
</text>

<!-- Section headers -->
<section name="customer-details">
  <text x="100" y="{{@section_y}}" font="sarabun-bold" size="14">
    รายละเอียดลูกค้า
  </text>
</section>
```

### Custom Functions
```xml
<!-- Register custom functions -->
<functions>
  <function name="calculate_discount">
    {{#if (gte amount 10000)}}
      {{multiply amount 0.1}}
    {{else if (gte amount 5000)}}
      {{multiply amount 0.05}}
    {{else}}
      0
    {{/if}}
  </function>
  
  <function name="thai_grade">
    {{#if (gte score 80)}}ดีเยี่ยม{{else if (gte score 70)}}ดี{{else if (gte score 60)}}พอใช้{{else if (gte score 50)}}ปรับปรุง{{else}}ไม่ผ่าน{{/if}}
  </function>
</functions>

<!-- Use custom functions -->
<text>ส่วนลด: ฿{{calculate_discount order.amount}}</text>
<text>เกรด: {{thai_grade student.score}}</text>
```

### Template Inheritance
```xml
<!-- Base template: base-invoice.xml -->
<pdf-template name="base-invoice">
  <page size="A4" margins="20,20,20,20">
    <header>
      <block name="company-header">
        <!-- Default company header -->
      </block>
    </header>
    
    <body>
      <block name="content">
        <!-- Content goes here -->
      </block>
    </body>
    
    <footer>
      <block name="page-footer">
        <!-- Default footer -->
      </block>
    </footer>
  </page>
</pdf-template>

<!-- Extended template -->
<pdf-template extends="base-invoice">
  <block name="company-header" mode="replace">
    <text x="100" y="750" font="sarabun-bold" size="16">
      บริษัท XYZ จำกัด
    </text>
  </block>
  
  <block name="content">
    <!-- Invoice-specific content -->
    <table>
      <!-- Table content -->
    </table>
  </block>
</pdf-template>
```

## 🎯 Best Practices

### Performance Optimization
```xml
<!-- Preload frequently used elements -->
<preload>
  <fonts>
    <font name="sarabun" file="Sarabun-Regular.ttf"/>
    <font name="sarabun-bold" file="Sarabun-Bold.ttf"/>
  </fonts>
  <images>
    <image name="logo" src="company-logo.png"/>
    <image name="signature" src="signature.png"/>
  </images>
</preload>

<!-- Use efficient data access patterns -->
{{#with customer}}
  <text>ชื่อ: {{name}}</text>
  <text>อีเมล: {{email}}</text>
  <text>โทรศัพท์: {{phone}}</text>
{{/with}}
```

### Error Handling
```xml
<!-- Safe property access -->
{{customer.name | default:'ไม่ระบุชื่อ'}}
{{customer.phone | default:'ไม่มีข้อมูล'}}

<!-- Conditional content -->
{{#if customer.email}}
  <text>อีเมล: {{customer.email}}</text>
{{else}}
  <text>ไม่มีข้อมูลอีเมล</text>
{{/if}}

<!-- Try-catch equivalent -->
{{#try}}
  {{complex_calculation}}
{{catch}}
  ไม่สามารถคำนวณได้
{{/try}}
```

### Internationalization
```xml
<!-- Language-specific templates -->
<pdf-template language="th-TH" currency="THB" date-format="thai">
  <text>{{greeting | localize}}</text>
  <text>{{date | localize}}</text>
  <text>{{amount | localize}}</text>
</pdf-template>

<!-- Multi-language content -->
<text>
  {{#if (eq @language 'th')}}สวัสดีครับ{{else}}Hello{{/if}}
</text>
```

## 📝 Template Validation

### Schema Definition
```xml
<!-- Template schema validation -->
<?xml version="1.0" encoding="utf-8"?>
<pdf-template 
  xmlns="http://dynamicpdflibrary.com/template/1.0"
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
  xsi:schemaLocation="http://dynamicpdflibrary.com/template/1.0 template.xsd">
  
  <!-- Template content with validation -->
  
</pdf-template>
```

### Common Validation Rules
- Font names must be registered in fonts section
- Coordinates must be within page boundaries
- Data sources must be defined before use
- Table column widths must sum to table width
- Color values must be valid hex or named colors
- Image sources must be accessible
- Variable names must follow naming conventions

---

This template reference provides comprehensive documentation for creating sophisticated PDF templates with full Thai language support. For more examples and advanced usage patterns, see the [examples directory](../examples/) in the repository.