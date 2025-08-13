## Using the Plugin

- **`np.reset`** — Resets the `List<Item>` pool.  
- **`np.info`** — Displays information about the current state of the `List<Item>` pool.

---

## Identifying Problematic Plugins

Follow these steps to help locate plugins that may be causing issues with the `List<Item>` pool:

1. **Install Notepad++** (if you haven’t already).  
2. **Download all plugins** from your server to your PC (or directly onto the server if it can run Notepad++).  
3. **Open all `.cs` files** in Notepad++.  
4. Press `CTRL+F` to open the Find dialog.  
5. Search for:  
    ```cs
    Get<List<Item>>()
    ```
6. Click **"Find All in All Open Documents"**.  
7. Close any tabs for plugins that do not have a match.

> **Note:** It’s normal to see many matches — lots of plugins use this pool.  
> The goal is to narrow down possible culprits.

---

## Resetting Without the Plugin

If you prefer not to use this plugin to reset the pool, simply restart your server — it will have the same effect.

---

## Important Testing Advice

After restarting or resetting the pool, **wait several hours** to see if the issue returns.  
Acting too quickly could lead you to misidentify the plugin causing the problem.
