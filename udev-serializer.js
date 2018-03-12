const buffer = require('buffer');

const createPaths = (o, replacements) => {
  return {
    Array:
      o.Array.map(({String}) => {
        const matcher = replacements.find(([matcher, newVal]) => {
          return matcher.test(String);
        });

        if (matcher) {
          const [a, replacement] = matcher;
          return {String: replacement};
        } else
          return {String};
      })}
}

module.exports = {
  print(x, serialize, indent) {
    const val = x.toString();
    const data = JSON.parse(val);
    let deviceData;
    const newData = Object.keys(data).reduce((acc, key) => {
      switch(key) {
        case "/devices/pci0000:00/0000:00:0d.0/ata3/host2/target2:0:0/2:0:0:0/block/sda/sda1":
          deviceData = data[key].Object.map(([k, v]) => {
            if (k === 'PATHS')
              return [k, createPaths(v, [[/\/dev\/disk\/by-uuid/, '/dev/disk/by-uuid/74b3fabd-dbf5-4cc0-a967-2c12f8113fa6']])];
            else return [k, v];
          });

          acc[key] = {
            Object: deviceData
          };
          break;

        case "/devices/pci0000:00/0000:00:0d.0/ata3/host2/target2:0:0/2:0:0:0/block/sda/sda2":
          deviceData = data[key].Object.map(([k, v]) => {
            if (k === 'PATHS')
              return [k, createPaths(v, [[/\/dev\/disk\/by-id\/lvm-pv-uuid/, '/dev/disk/by-id/lvm-pv-uuid-tVAIF5-nJY7-oKaP-wLQO-OIXp-Ggwn-0F9F70']])];
            else return [k, v];
          });

          acc[key] = {
            Object: deviceData
          };
          break;

        case "/devices/virtual/block/dm-0":
          deviceData = data[key].Object.map(([k, v]) => {
            if (k === 'PATHS')
              return [k, createPaths(v, [
                [/\/dev\/disk\/by-id\/dm-uuid-LVM/, '/dev/disk/by-id/dm-uuid-LVM-FpAffE3HiAwoAvd81g8dBirIbkC3Ogu58AIfMI4SXo1AodrQkxuO2yuvd2JOPi5j'],
                [/\/dev\/disk\/by-uuid\//, '/dev/disk/by-uuid/45252d52-d8d6-468e-aaa0-c117b042944a']
              ])];
            else if (k == 'DM_UUID')
                return [k, {String: 'LVM-FpAffE3HiAwoAvd81g8dBirIbkC3Ogu58AIfMI4SXo1AodrQkxuO2yuvd2JOPi5j'}];
            else return [k, v];
          });

          acc[key] = {
            Object: deviceData
          };
          break;
        case "/devices/virtual/block/dm-1":
          deviceData = data[key].Object.map(([k, v]) => {
            if (k === 'PATHS')
              return [k, createPaths(v, [
                [/\/dev\/disk\/by-id\/dm-uuid-LVM/, '/dev/disk/by-id/dm-uuid-LVM-FpAffE3HiAwoAvd81g8dBirIbkC3Ogu50snmtLIcILKydXKz4EgqhgxR5Tf013zE'],
                [/\/dev\/disk\/by-uuid\//, '/dev/disk/by-uuid/4af3b3ab-356b-490b-9aab-2e9786804b79']
              ])];
            else if (k == 'DM_UUID')
                return [k, {String: 'LVM-FpAffE3HiAwoAvd81g8dBirIbkC3Ogu50snmtLIcILKydXKz4EgqhgxR5Tf013zE'}];
            else return [k, v];
          });

          acc[key] = {
            Object: deviceData
          };
          break;
        default:
          acc[key] = data[key];
      }


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
