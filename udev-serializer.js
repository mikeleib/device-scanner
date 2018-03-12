const buffer = require('buffer');

module.exports = {
  print(x, serialize, indent) {
    const val = x.toString();
    const data = JSON.parse(val);
    const newData = Object.keys(data).reduce((acc, key) => {
      if (key == "/devices/pci0000:00/0000:00:0d.0/ata3/host2/target2:0:0/2:0:0:0/block/sda/sda1") {
        const deviceData = data[key].Object.map(([k, v]) => {
          if (k === 'PATHS')
            return [k, {
              Array:
                v.Array.map(({String}) => {
                  if (/\/dev\/disk\/by-uuid/.test(String))
                    return {String: '/dev/disk/by-uuid/74b3fabd-dbf5-4cc0-a967-2c12f8113fa6'};
                  else
                    return {String};
                })}
              ];
          else return [k, v];
        });

        acc[key] = {
          Object: deviceData
        };
      } else if (key == "/devices/pci0000:00/0000:00:0d.0/ata3/host2/target2:0:0/2:0:0:0/block/sda/sda2") {
        const deviceData = data[key].Object.map(([k, v]) => {
          if (k === 'PATHS')
            return [k, {
              Array:
                v.Array.map(({String}) => {
                  if (/\/dev\/disk\/by-id\/lvm-pv-uuid/.test(String))
                    return {String: '/dev/disk/by-id/lvm-pv-uuid-tVAIF5-nJY7-oKaP-wLQO-OIXp-Ggwn-0F9F70'};
                  else
                    return {String};
                })}
              ];
          else return [k, v];
        });

        acc[key] = {
          Object: deviceData
        };
      } else if (key == "/devices/virtual/block/dm-0") {
        const deviceData = data[key].Object.map(([k, v]) => {
          if (k === 'PATHS')
            return [k, {
              Array:
                v.Array.map(({String}) => {
                  if (/\/dev\/disk\/by-id\/dm-uuid-LVM/.test(String))
                    return {String: '/dev/disk/by-id/dm-uuid-LVM-FpAffE3HiAwoAvd81g8dBirIbkC3Ogu58AIfMI4SXo1AodrQkxuO2yuvd2JOPi5j'};
                  else if (/\/dev\/disk\/by-uuid\//.test(String))
                    return {String: '/dev/disk/by-uuid/45252d52-d8d6-468e-aaa0-c117b042944a'};
                  else
                    return {String};
                })}
              ];
          else if (k == 'DM_UUID')
              return [k, {String: 'LVM-FpAffE3HiAwoAvd81g8dBirIbkC3Ogu58AIfMI4SXo1AodrQkxuO2yuvd2JOPi5j'}];
          else return [k, v];
        });

        acc[key] = {
          Object: deviceData
        };
      } else if (key == "/devices/virtual/block/dm-1") {
        const deviceData = data[key].Object.map(([k, v]) => {
          if (k === 'PATHS')
            return [k, {
              Array:
                v.Array.map(({String}) => {
                  if (/\/dev\/disk\/by-id\/dm-uuid-LVM/.test(String))
                    return {String: '/dev/disk/by-id/dm-uuid-LVM-FpAffE3HiAwoAvd81g8dBirIbkC3Ogu50snmtLIcILKydXKz4EgqhgxR5Tf013zE'};
                  else if (/\/dev\/disk\/by-uuid\//.test(String))
                    return {String: '/dev/disk/by-uuid/4af3b3ab-356b-490b-9aab-2e9786804b79'};
                  else
                    return {String};
                })}
              ];
          else if (k == 'DM_UUID')
              return [k, {String: 'LVM-FpAffE3HiAwoAvd81g8dBirIbkC3Ogu50snmtLIcILKydXKz4EgqhgxR5Tf013zE'}];
          else return [k, v];
        });

        acc[key] = {
          Object: deviceData
        };
      } else
        acc[key] = data[key];

      return acc;
    }, {});

    try {
      return serialize(JSON.stringify(newData, null, 2));
    } catch (e) {
      return serialize(val);
    }
  },

  test(x) {
    return x && buffer.Buffer.isBuffer(x);
  },
};
