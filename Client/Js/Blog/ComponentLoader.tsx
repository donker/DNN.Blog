import * as React from "react";
import * as ReactDOM from "react-dom";
import * as $ from "jquery";

import { AppManager } from "./AppManager";
import Foo from "./Components/Foo";

export class ComponentLoader {
  public static load(): void {
    $(".Blog").each(function(i, el) {
        var moduleId = $(el).data("moduleid");
        ReactDOM.render(
          <Foo
            module={AppManager.Modules.Item(moduleId.toString())}
            bar={$(el).data("bar")}
          />,
          el
        );
      });
    }
}
