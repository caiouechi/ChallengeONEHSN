 Important points I considered:
    <ul>
        <li>A rectangle can be on the same spot of other rectangles</li>
        <li>To know if a coordinate is inside a rectangle I separated the rectangle in 2 triangles and checked if the coordiante is inside of one of them</li>
        <li>I installed a SQL server on Azure portal to do this challenge</li>
        <li>I created a youtube video to make the presentation easier</li>
        <li>I created an N-tier project API+BLL+DALL</li>
        <li>I created another table called Special rectangles just to show I know how to implement foreign keys. I preferred to not create another table for the coordinates to gain even more performance doing the search/insert rectangle executions</li>
        <li>I assumed all rectangles will follow the following structure: ABCD (from left to the right, from bottm to top), this is important for the coordinates logic:
            <img src="~/Content/img/TableDesign.JPG" alt="Rectangle structure" />
        </li>

        <li>For the "Any further design considerations assuming scaling this system and integrations with external consumers.", I would consider the microservices architecture where every new service of external tool should be a different DLL or api. Our BLL would handle these different sources.</li>
    </ul>
